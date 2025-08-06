using StajOdeviIlkNet8.Models;
using StajOdeviIlkNet8.Repositories;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;

namespace StajOdeviIlkNet8.Repository
{
    public class SheepRepository(FarmDbContext context) : AnimalRepository(context), ISheepRepository
    {
        private readonly FarmDbContext _context = context;

        public void IncrementWoolCount(int sheepId)
        {
            var sheep = _context.Sheeps.FirstOrDefault(s => s.Id == sheepId && s.IsAlive);
            if (sheep != null)
            {
                sheep.WoolProductionCount = (sheep.WoolProductionCount ?? 0) + 1;
                _context.SaveChanges();
            }
        }

        public int GetWoolCount(int sheepId)
        {
            var sheep = _context.Sheeps.FirstOrDefault(s => s.Id == sheepId && s.IsAlive);
            return sheep?.WoolProductionCount ?? 0;
        }

        public Sheep? GetAliveSheep()
        {
            return _context.Sheeps.FirstOrDefault(s => s.IsAlive);
        }

        public int? GetAliveSheepId()
        {
            var sheep = GetAliveSheep();
            return sheep?.Id;
        }

        public int GetSheepAgeById(int sheepId)
        {
            var sheep = _context.Sheeps.FirstOrDefault(s => s.Id == sheepId);
            return sheep?.Age ?? 0;
        }
    }
}
