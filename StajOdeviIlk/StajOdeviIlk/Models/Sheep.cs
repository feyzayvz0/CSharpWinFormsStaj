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
            // Örnek: yeni bir ürün (yün) üret
            return new Product
            {
                AnimalId = this.Id,
                ProductTypeId = 3, // 3 diyelim yün ürün tipi id'si
                Quantity = 1
            };
        }

        public override void AgeUp()
        {
            base.AgeUp(); // yaş artışı

            if (Age >= Lifespan)
                IsAlive = false;
        }
    }
}

