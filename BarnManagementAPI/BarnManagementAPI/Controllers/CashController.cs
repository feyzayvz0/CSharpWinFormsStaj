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
    public class CashController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CashController(AppDbContext db) => _db = db;

        [HttpPost("add")]
        public async Task<ActionResult<BalanceResponse>> Add([FromBody] AddCashRequest req, CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();
            if (req.Amount <= 0) return BadRequest("Amount must be greater than zero.");

            if (req.FarmId is int farmId)
            {
                var owns = await _db.Farms.AnyAsync(f => f.Id == farmId && f.UserId == userId, ct);
                if (!owns) return NotFound("Farm not found or not yours.");
            }

            var user = await _db.Users.FirstAsync(u => u.Id == userId, ct);
            user.Balance += req.Amount;
            await _db.SaveChangesAsync(ct);

            return Ok(new BalanceResponse { Balance = user.Balance });
        }

        [HttpGet("balance")]
        public async Task<ActionResult<BalanceResponse>> GetBalance(CancellationToken ct)
        {
            var userId = User.GetUserId();
            if (userId is null) return Unauthorized();

            var bal = await _db.Users.AsNoTracking()
                .Where(u => u.Id == userId).Select(u => u.Balance).FirstAsync(ct);

            return Ok(new BalanceResponse { Balance = bal });
        }
    }
}
