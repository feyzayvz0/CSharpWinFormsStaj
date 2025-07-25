using StajOdeviIlk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Models
{
    public class Sheep : Animal
    {
        public override Product Produce()
        {
           
            return new Product
            {
                AnimalId = this.Id,
                ProductTypeId = 3, 
                Quantity = 1
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

