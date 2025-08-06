using StajOdeviIlkNet8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Models
{
    public class Chicken : Animal
    {
        public int? EggProductionCount { get; set; }

        public override Product Produce()
        {
            return new Product
            {
                ProductTypeId = 1,
                Quantity = 1,
                ProductionDate = DateTime.Now
            };
        }
    }
}
