using StajOdeviIlk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Models
{
    public class Chicken : Animal
    {
        public override Product Produce()
        {
            return new Product
            {
                ProductTypeId = 1, // 1 = Egg (veritabanındaki ProductTypes tablosuna göre)
                Quantity = 1,
                ProductionDate = DateTime.Now
            };
        }
    }
}