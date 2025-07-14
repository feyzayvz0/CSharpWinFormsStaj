using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace StajOdeviIlk.Models
    {
    public abstract class Animal
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Lifespan { get; set; }


        public abstract Product Produce();
    }
}

