using System;
using StajOdeviIlkNet8.Models;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public int ProductTypeId { get; set; } 
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public bool IsSold { get; set; }

        public virtual ProductType? ProductType { get; set; }
        public virtual Animal? Animal { get; set; }

    }
}

