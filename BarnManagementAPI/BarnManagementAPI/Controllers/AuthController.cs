using BarnManagementAPI.Data;
using BarnManagementAPI.Models;
using BarnManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BarnManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IJwtTokenService _jwt;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthController(AppDbContext db, IJwtTokenService jwt)
        {
            _db = db; _jwt = jwt;
        }

        public record RegisterDto(string Username, string Email, string Password);
        public record LoginDto(string Username, string Password);

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _db.Users.AnyAsync(u => u.Username == dto.Username || u.Email == dto.Email))
                return BadRequest("Username or email already exists.");

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email
            };
            user.PasswordHash = _hasher.HashPassword(user, dto.Password);

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            var token = _jwt.CreateToken(user.Id, user.Username);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user is null) return Unauthorized();

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed) return Unauthorized();

            var token = _jwt.CreateToken(user.Id, user.Username);
            return Ok(new { token });
        }
    }
}
