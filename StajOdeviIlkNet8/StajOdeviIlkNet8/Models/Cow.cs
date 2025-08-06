using StajOdeviIlkNet8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Models
{
    public class Cow : Animal
    {
        public int? MilkProductionCount { get; set; }

        public override Product Produce()
        {
            return new Product
            {
                AnimalId = this.Id,
                ProductTypeId = 2,
                Quantity = 1,
                ProductionDate = DateTime.Now
            };
        }

        public override void AgeUp()
        {
            base.AgeUp();

            if (Age >= Lifespan)
                IsAlive = false;
        }
    }
}

