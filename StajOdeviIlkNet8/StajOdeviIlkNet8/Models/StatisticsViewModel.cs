using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Models
{
    public class StatisticsViewModel
    {
        public string AnimalType { get; set; } = string.Empty;

        public int DeadAnimals { get; set; }
        public int EggsInStock { get; set; }
        public int EggsSold { get; set; }
        public int MilkInStock { get; set; }
        public int MilkSold { get; set; }
        public int WoolInStock { get; set; }
        public int WoolSold { get; set; }
        public int FeathersInStock { get; set; }
        public int FeathersSold { get; set; }
        public decimal TotalEarnedCash { get; set; }
    }

}
