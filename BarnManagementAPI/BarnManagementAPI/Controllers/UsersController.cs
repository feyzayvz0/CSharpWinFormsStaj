using BarnManagementAPI.Common;
using BarnManagementAPI.Data;
using BarnManagementAPI.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarnManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;
        public UsersController(AppDbContext db) => _db = db;

        // GET /api/users/me
        [HttpGet("me")]
        public async Task<ActionResult<UserProfileResponse>> GetMe(CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var u = await _db.Users.AsNoTracking().FirstAsync(x => x.Id == userId, ct);
            return Ok(new UserProfileResponse
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Balance = u.Balance
            });
        }

        // PUT /api/users/me
        [HttpPut("me")]
        public async Task<IActionResult> UpdateMe([FromBody] UpdateUserRequest req, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var u = await _db.Users.FirstAsync(x => x.Id == userId, ct);

            if (!string.IsNullOrWhiteSpace(req.Email))
            {
                var exists = await _db.Users.AnyAsync(x => x.Email == req.Email && x.Id != userId, ct);
                if (exists) return BadRequest("Email already used.");
                u.Email = req.Email;
            }

            if (!string.IsNullOrWhiteSpace(req.Username))
            {
                var exists = await _db.Users.AnyAsync(x => x.Username == req.Username && x.Id != userId, ct);
                if (exists) return BadRequest("Username already used.");
                u.Username = req.Username;
            }

            if (req.Balance is decimal b && b >= 0) // güvenlik notu
                u.Balance = b;

            await _db.SaveChangesAsync(ct);
            return NoContent();
        }
    }
}
