using BarnManagementAPI.Common;
using BarnManagementAPI.Data;
using BarnManagementAPI.Models;
using BarnManagementAPI.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; 

namespace BarnManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<ProductsController> _logger; 

        public ProductsController(AppDbContext db, ILogger<ProductsController> logger) 
        {
            _db = db;
            _logger = logger;
        }

        private static readonly Dictionary<string, (string productType, decimal unitPrice, TimeSpan cooldown)> Rules
            = new(StringComparer.OrdinalIgnoreCase)
            {
                ["Chicken"] = ("Egg", 5m, TimeSpan.FromHours(8)),
                ["Cow"] = ("Milk", 12m, TimeSpan.FromHours(12)),
                ["Sheep"] = ("Wool", 30m, TimeSpan.FromDays(3)),
                ["Goose"] = ("Feather", 8m, TimeSpan.FromDays(1))
            };


        [HttpPost("produce")]
        public async Task<ActionResult<ProductResponse>> Produce([FromBody] ProduceRequest req, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var animal = await _db.Animals
                .Include(a => a.Farm)
                .FirstOrDefaultAsync(a => a.Id == req.AnimalId && a.Farm.UserId == userId, ct);

            if (animal is null)
            {
                _logger.LogWarning("Produce failed: animal not found or not owned. req.AnimalId={AnimalId}, user={UserId}", req.AnimalId, userId);
                return NotFound("Animal not found or not yours.");
            }

            if (!animal.IsAlive)
            {
                _logger.LogWarning("Produce failed: animal not alive. animalId={AnimalId}, user={UserId}", animal.Id, userId);
                return BadRequest("Animal is not alive.");
            }

            if (!Rules.TryGetValue(animal.Species, out var rule))
            {
                _logger.LogWarning("Produce failed: no rule for species. species={Species}, animalId={AnimalId}, user={UserId}", animal.Species, animal.Id, userId);
                return BadRequest("No production rule for this species.");
            }

            var now = DateTime.UtcNow;
            if (animal.NextProductionAt is DateTime next && now < next)
            {
                _logger.LogWarning("Produce blocked by cooldown. animalId={AnimalId}, user={UserId}, now={Now}, next={Next}",
                    animal.Id, userId, now, next);
                return BadRequest($"Production not ready. Try after {next:O}");
            }

            
            var product = new Product
            {
                AnimalId = animal.Id,
                ProductType = rule.productType,
                Quantity = 1,
                SalePrice = rule.unitPrice,
                IsSold = false,
                ProductionDate = now
            };
            _db.Products.Add(product);

           
            animal.NextProductionAt = now.Add(rule.cooldown);
            await _db.SaveChangesAsync(ct);

            _logger.LogInformation("Product produced: productId={ProductId}, type={Type}, animalId={AnimalId}, user={UserId}",
                product.Id, product.ProductType, animal.Id, userId);

            return Ok(new ProductResponse
            {
                Id = product.Id,
                AnimalId = product.AnimalId,
                ProductType = product.ProductType,
                Quantity = product.Quantity,
                SalePrice = product.SalePrice,
                IsSold = product.IsSold,
                ProductionDate = product.ProductionDate
            });
        }

        
        [HttpPost("sell")]
        public async Task<IActionResult> Sell([FromBody] SellProductRequest req, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var product = await _db.Products
                .Include(p => p.Animal)
                .ThenInclude(a => a.Farm)
                .ThenInclude(f => f.User)
                .FirstOrDefaultAsync(p => p.Id == req.ProductId && p.Animal.Farm.UserId == userId, ct);

            if (product is null)
            {
                _logger.LogWarning("Sell failed: product not found or not owned. productId={ProductId}, user={UserId}", req.ProductId, userId);
                return NotFound("Product not found or not yours.");
            }

            if (product.IsSold)
            {
                _logger.LogWarning("Sell failed: product already sold. productId={ProductId}, user={UserId}", product.Id, userId);
                return BadRequest("Product already sold.");
            }

            var total = product.SalePrice * product.Quantity;

            
            var user = await _db.Users.FirstAsync(u => u.Id == userId, ct);
            user.Balance += total;

            product.IsSold = true;
            await _db.SaveChangesAsync(ct);

            _logger.LogInformation("Product sold: productId={ProductId}, total={Total}, newBalance={Balance}, user={UserId}",
                product.Id, total, user.Balance, userId);

            return Ok(new { message = "Product sold.", received = total, newBalance = user.Balance });
        }

        
        [HttpPost("sell-all")]
        public async Task<IActionResult> SellAll([FromBody] SellAllRequest req, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

           
            var owns = await _db.Farms.AnyAsync(f => f.Id == req.FarmId && f.UserId == userId, ct);
            if (!owns)
            {
                _logger.LogWarning("SellAll failed: farm not found or not owned. farmId={FarmId}, user={UserId}", req.FarmId, userId);
                return NotFound("Farm not found or not yours.");
            }

            var query = _db.Products
                .Include(p => p.Animal)
                .Where(p => !p.IsSold && p.Animal.FarmId == req.FarmId);

            if (!string.IsNullOrWhiteSpace(req.ProductType))
                query = query.Where(p => p.ProductType == req.ProductType);

            var list = await query.ToListAsync(ct);
            if (list.Count == 0)
            {
                _logger.LogInformation("SellAll: nothing to sell. farmId={FarmId}, user={UserId}", req.FarmId, userId);
                return Ok(new { message = "No unsold products." });
            }

            decimal total = list.Sum(p => p.SalePrice * p.Quantity);

            var user = await _db.Users.FirstAsync(u => u.Id == userId, ct);
            user.Balance += total;

            foreach (var p in list) p.IsSold = true;

            await _db.SaveChangesAsync(ct);

            _logger.LogInformation("SellAll: soldCount={Count}, received={Total}, newBalance={Balance}, farmId={FarmId}, user={UserId}",
                list.Count, total, user.Balance, req.FarmId, userId);

            return Ok(new { message = "All products sold.", count = list.Count, received = total, newBalance = user.Balance });
        }

        // GET /api/products/unsold/by-farm/{farmId}
        [HttpGet("unsold/by-farm/{farmId:int}")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetUnsoldByFarm(int farmId, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var owns = await _db.Farms.AnyAsync(f => f.Id == farmId && f.UserId == userId, ct);
            if (!owns)
            {
                _logger.LogWarning("GetUnsoldByFarm failed: farm not found or not owned. farmId={FarmId}, user={UserId}", farmId, userId);
                return NotFound("Farm not found or not yours.");
            }

            var items = await _db.Products
                .Include(p => p.Animal)
                .Where(p => !p.IsSold && p.Animal.FarmId == farmId)
                .OrderByDescending(p => p.ProductionDate)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    AnimalId = p.AnimalId,
                    ProductType = p.ProductType,
                    Quantity = p.Quantity,
                    SalePrice = p.SalePrice,
                    IsSold = p.IsSold,
                    ProductionDate = p.ProductionDate
                })
                .ToListAsync(ct);

            _logger.LogInformation("GetUnsoldByFarm: count={Count}, farmId={FarmId}, user={UserId}", items.Count, farmId, userId);
            return Ok(items);
        }

        // GET /api/products/mine?sold=true&farmId=1&productType=Egg&page=1&pageSize=50
        [HttpGet("mine")]
        public async Task<ActionResult<ProductListResult>> GetMine(
            [FromQuery] bool? sold,
            [FromQuery] int? farmId,
            [FromQuery] string? productType,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 50,
            CancellationToken ct = default)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            if (page <= 0) page = 1;
            if (pageSize <= 0 || pageSize > 200) pageSize = 50;

           
            var query = _db.Products
                .Include(p => p.Animal)
                .ThenInclude(a => a.Farm)
                .Where(p => p.Animal.Farm.UserId == userId);

            if (sold is not null)
                query = query.Where(p => p.IsSold == sold.Value);

            if (farmId is not null)
                query = query.Where(p => p.Animal.FarmId == farmId.Value);

            if (!string.IsNullOrWhiteSpace(productType))
                query = query.Where(p => p.ProductType == productType);

            var total = await query.CountAsync(ct);

            var items = await query
                .OrderByDescending(p => p.ProductionDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    AnimalId = p.AnimalId,
                    ProductType = p.ProductType,
                    Quantity = p.Quantity,
                    SalePrice = p.SalePrice,
                    IsSold = p.IsSold,
                    ProductionDate = p.ProductionDate
                })
                .ToListAsync(ct);

            _logger.LogInformation("GetMine: total={Total}, returned={Returned}, user={UserId}, sold={Sold}, farmId={FarmId}, type={Type}, page={Page}, size={Size}",
                total, items.Count, userId, sold, farmId, productType, page, pageSize);

            return Ok(new ProductListResult { Total = total, Items = items });
        }
    }
}
