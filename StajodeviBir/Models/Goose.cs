using StajodeviBir.Models.StajodeviBir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajodeviBir.Models
{
    public class Goose : Animal
    {
        public override Product Produce()
        {
            return new Product
            {
                ProductName = "Feather",
                Quantity = 1,
                ProductionDate = DateTime.Now,
                AnimalId = this.Id
            };
        }
    }
}