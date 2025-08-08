using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarnManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        [Precision(18, 2)] // veya: [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; } = 0m;

        public ICollection<Farm> Farms { get; set; } = new List<Farm>();
    }
}

