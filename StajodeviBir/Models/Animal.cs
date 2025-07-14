using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajodeviBir.Models
{
    namespace StajodeviBir.Models
    {
        public abstract class Animal
        {
            public int Id { get; set; }
            public string Species { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public int Lifespan { get; set; }
            public bool IsAlive { get; set; } = true;

            public abstract Product Produce(); // her hayvan bir ürün üretir
        }
    }
}
