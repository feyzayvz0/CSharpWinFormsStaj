using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajodeviBir.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public bool IsSold { get; set; }
    }
}

