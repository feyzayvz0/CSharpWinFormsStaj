using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BarnManagementAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; } = null!;
        public string ProductType { get; set; } = null!;
        public int Quantity { get; set; }

        [Precision(18, 2)] // veya: [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }

        public bool IsSold { get; set; } = false;
        public DateTime ProductionDate { get; set; } = DateTime.UtcNow;
    }
}

