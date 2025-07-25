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
                ProductTypeId = 2, 
                Quantity = 1,
                ProductionDate = DateTime.Now
            };
        }
    }
}

