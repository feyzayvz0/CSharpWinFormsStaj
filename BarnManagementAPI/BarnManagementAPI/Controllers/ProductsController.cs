using BarnManagementAPI.Common;
using BarnManagementAPI.Data;
using BarnManagementAPI.Models;
using BarnManagementAPI.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarnManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext db) => _db = db;

        // Basit üretim kuralları (ileride DB'ye alabiliriz)
        private static readonly Dictionary<string, (string productType, decimal unitPrice, TimeSpan cooldown)> Rules
            = new(StringComparer.OrdinalIgnoreCase)
            {
                ["Chicken"] = ("Egg", 5m, TimeSpan.FromHours(8)),
                ["Cow"] = ("Milk", 12m, TimeSpan.FromHours(12)),
                ["Sheep"] = ("Wool", 30m, TimeSpan.FromDays(3)),
                ["Goose"] = ("Feather", 8m, TimeSpan.FromDays(1))
            };

        // POST /api/products/produce  => 1 adet ürün üret
        [HttpPost("produce")]
        public async Task<ActionResult<ProductResponse>> Produce([FromBody] ProduceRequest req, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var animal = await _db.Animals
                .Include(a => a.Farm)
                .FirstOrDefaultAsync(a => a.Id == req.AnimalId && a.Farm.UserId == userId, ct);

            if (animal is null) return NotFound("Animal not found or not yours.");
            if (!animal.IsAlive) return BadRequest("Animal is not alive.");

            if (!Rules.TryGetValue(animal.Species, out var rule))
                return BadRequest("No production rule for this species.");

            // Cooldown kontrolü
            var now = DateTime.UtcNow;
            if (animal.NextProductionAt is DateTime next && now < next)
                return BadRequest($"Production not ready. Try after {next:O}");

            // Ürünü oluştur
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

            // bir sonraki üretim zamanı
            animal.NextProductionAt = now.Add(rule.cooldown);

            await _db.SaveChangesAsync(ct);

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

        // POST /api/products/sell  => tek ürünü sat
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

            if (product is null) return NotFound("Product not found or not yours.");
            if (product.IsSold) return BadRequest("Product already sold.");

            // Bakiyeye ekle
            var user = await _db.Users.FirstAsync(u => u.Id == userId, ct);
            user.Balance += product.SalePrice * product.Quantity;

            product.IsSold = true;
            await _db.SaveChangesAsync(ct);

            return Ok(new { message = "Product sold.", received = product.SalePrice * product.Quantity, newBalance = user.Balance });
        }

        // POST /api/products/sell-all  => belirli çiftlikte (ve opsiyonel tipte) tüm satılmamış ürünleri sat
        [HttpPost("sell-all")]
        public async Task<IActionResult> SellAll([FromBody] SellAllRequest req, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            // Kullanıcının çiftliği mi?
            var owns = await _db.Farms.AnyAsync(f => f.Id == req.FarmId && f.UserId == userId, ct);
            if (!owns) return NotFound("Farm not found or not yours.");

            var query = _db.Products
                .Include(p => p.Animal)
                .Where(p => !p.IsSold && p.Animal.FarmId == req.FarmId);

            if (!string.IsNullOrWhiteSpace(req.ProductType))
                query = query.Where(p => p.ProductType == req.ProductType);

            var list = await query.ToListAsync(ct);
            if (list.Count == 0) return Ok(new { message = "No unsold products." });

            decimal total = list.Sum(p => p.SalePrice * p.Quantity);

            var user = await _db.Users.FirstAsync(u => u.Id == userId, ct);
            user.Balance += total;

            foreach (var p in list) p.IsSold = true;

            await _db.SaveChangesAsync(ct);

            return Ok(new { message = "All products sold.", count = list.Count, received = total, newBalance = user.Balance });
        }

        // GET /api/products/unsold/by-farm/{farmId}
        [HttpGet("unsold/by-farm/{farmId:int}")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetUnsoldByFarm(int farmId, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var owns = await _db.Farms.AnyAsync(f => f.Id == farmId && f.UserId == userId, ct);
            if (!owns) return NotFound("Farm not found or not yours.");

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

            return Ok(items);
        }
    }
}
