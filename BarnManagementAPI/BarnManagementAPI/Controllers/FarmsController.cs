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
    public class FarmsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public FarmsController(AppDbContext db)
        {
            _db = db;
        }

        // POST: /api/farms
        [HttpPost]
        public async Task<ActionResult<FarmResponse>> Create([FromBody] CreateFarmRequest req, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var farm = new Farm
            {
                Name = req.Name,
                UserId = userId.Value,
                CreatedAt = DateTime.UtcNow
            };

            _db.Farms.Add(farm);
            await _db.SaveChangesAsync(ct);

            var resp = new FarmResponse
            {
                Id = farm.Id,
                Name = farm.Name,
                CreatedAt = farm.CreatedAt
            };

            return CreatedAtAction(nameof(GetById), new { id = farm.Id }, resp);
        }

        // GET: /api/farms/mine
        [HttpGet("mine")]
        public async Task<ActionResult<IEnumerable<FarmResponse>>> GetMine(CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var farms = await _db.Farms
                .Where(f => f.UserId == userId.Value)
                .OrderByDescending(f => f.Id)
                .Select(f => new FarmResponse
                {
                    Id = f.Id,
                    Name = f.Name,
                    CreatedAt = f.CreatedAt
                })
                .ToListAsync(ct);

            return Ok(farms);
        }

        // GET: /api/farms/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FarmResponse>> GetById(int id, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var farm = await _db.Farms
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id && f.UserId == userId.Value, ct);

            if (farm is null) return NotFound();

            return new FarmResponse
            {
                Id = farm.Id,
                Name = farm.Name,
                CreatedAt = farm.CreatedAt
            };
        }

        // PUT: /api/farms/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateFarmRequest req, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var farm = await _db.Farms.FirstOrDefaultAsync(f => f.Id == id && f.UserId == userId.Value, ct);
            if (farm is null) return NotFound();

            farm.Name = req.Name;

            await _db.SaveChangesAsync(ct);
            return NoContent();
        }

        // DELETE /api/farms/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var farm = await _db.Farms.Include(f => f.Animals).FirstOrDefaultAsync(f => f.Id == id && f.UserId == userId, ct);
            if (farm is null) return NotFound();

           
            _db.Farms.Remove(farm);
            await _db.SaveChangesAsync(ct);
            return NoContent();
        }
    }
}
