using StajOdeviIlkNet8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Models
{
    public class Goose : Animal
    {
        public int? FeatherProductionCount { get; set; }

        public override Product Produce()
        {
            return new Product
            {
                ProductTypeId = 4,
                Quantity = 1,
                ProductionDate = DateTime.Now
            };
        }
    }
}
