using StajOdeviIlkNet8.Models;
using StajOdeviIlkNet8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Repository
{
    public class ChickenRepository : AnimalRepository, IChickenRepository
    {
        private readonly FarmDbContext _context;

        public ChickenRepository(FarmDbContext context) : base(context)
        {
            _context = context;
        }

        public void IncrementEggCount(int animalId)
        {
            var chicken = _context.Chickens.FirstOrDefault(c => c.Id == animalId && c.IsAlive);
            if (chicken != null)
            {
                chicken.EggProductionCount = (chicken.EggProductionCount ?? 0) + 1;
                _context.SaveChanges();
            }
        }

        public int GetEggCount(int animalId)
        {
            var chicken = _context.Chickens.FirstOrDefault(c => c.Id == animalId && c.IsAlive);
            return chicken?.EggProductionCount ?? 0;
        }

        public Chicken GetAliveChicken()
        {
            return _context.Chickens.FirstOrDefault(c => c.IsAlive);
        }
    }
}
