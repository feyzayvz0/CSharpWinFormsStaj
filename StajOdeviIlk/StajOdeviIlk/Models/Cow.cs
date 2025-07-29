using StajOdeviIlk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Models
{
    public class Cow : Animal
    {
        public override Product Produce()
        {
            return new Product
            {
                AnimalId = this.Id,      // Bu çok önemli!
                ProductTypeId = 2,       // 2 = Süt
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


