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
    public class AnimalsController : ControllerBase
    {
        private readonly AppDbContext _db;

        // Basit fiyat tablosu (ileride DB'ye alabiliriz)
        private static readonly Dictionary<string, decimal> Prices = new(StringComparer.OrdinalIgnoreCase)
        {
            ["Chicken"] = 50m,
            ["Cow"] = 500m,
            ["Sheep"] = 200m,
            ["Goose"] = 100m
        };

        public AnimalsController(AppDbContext db) => _db = db;

        // POST: /api/animals/buy
        [HttpPost("buy")]
        public async Task<IActionResult> Buy([FromBody] BuyAnimalRequest req, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var farm = await _db.Farms.FirstOrDefaultAsync(f => f.Id == req.FarmId && f.UserId == userId, ct);
            if (farm is null) return NotFound("Farm not found or not yours.");

            if (!Prices.TryGetValue(req.Species, out var price))
                return BadRequest("Unknown species.");

            var user = await _db.Users.FirstAsync(u => u.Id == userId, ct);
            if (user.Balance < price)
                return BadRequest("Insufficient balance.");

            user.Balance -= price;

            var animal = new Animal
            {
                FarmId = farm.Id,
                Species = req.Species,
                Gender = req.Gender,
                Age = 0,
                Lifespan = req.Species.Equals("Chicken", StringComparison.OrdinalIgnoreCase) ? 365 :
                           req.Species.Equals("Sheep", StringComparison.OrdinalIgnoreCase) ? 730 :
                           req.Species.Equals("Goose", StringComparison.OrdinalIgnoreCase) ? 730 :
                           1460, // Cow default
                IsAlive = true,
                NextProductionAt = null
            };

            _db.Animals.Add(animal);
            await _db.SaveChangesAsync(ct);

            return Ok(new { message = "Animal bought.", animalId = animal.Id, newBalance = user.Balance });
        }

        // POST: /api/animals/sell
        [HttpPost("sell")]
        public async Task<IActionResult> Sell([FromBody] SellAnimalRequest req, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var animal = await _db.Animals
                .Include(a => a.Farm)
                .ThenInclude(f => f.User)
                .FirstOrDefaultAsync(a => a.Id == req.AnimalId && a.Farm.UserId == userId, ct);

            if (animal is null) return NotFound("Animal not found or not yours.");

            // Basit satış bedeli: alış fiyatının %60'ı varsayalım
            var species = animal.Species;
            if (!Prices.TryGetValue(species, out var buyPrice)) buyPrice = 0m;
            var sellPrice = Math.Round(buyPrice * 0.6m, 2);

            var user = await _db.Users.FirstAsync(u => u.Id == userId, ct);
            user.Balance += sellPrice;

            // Hayvanı öldü/satıldı kabul edelim (sistemden kaldırabilir veya flag atabiliriz)
            _db.Animals.Remove(animal);
            await _db.SaveChangesAsync(ct);

            return Ok(new { message = "Animal sold.", received = sellPrice, newBalance = user.Balance });
        }

        // GET: /api/animals/by-farm/{farmId}
        [HttpGet("by-farm/{farmId:int}")]
        public async Task<ActionResult<IEnumerable<AnimalResponse>>> GetByFarm(int farmId, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var owns = await _db.Farms.AnyAsync(f => f.Id == farmId && f.UserId == userId, ct);
            if (!owns) return NotFound("Farm not found or not yours.");

            var animals = await _db.Animals
                .Where(a => a.FarmId == farmId)
                .Select(a => new AnimalResponse
                {
                    Id = a.Id,
                    FarmId = a.FarmId,
                    Species = a.Species,
                    Gender = a.Gender,
                    Age = a.Age,
                    Lifespan = a.Lifespan,
                    IsAlive = a.IsAlive
                })
                .ToListAsync(ct);

            return Ok(animals);
        }
    }
}
