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
    public class GooseRepository(FarmDbContext context) : AnimalRepository(context), IGooseRepository
    {
        private readonly FarmDbContext _context = context;

        public void IncrementFeatherCount(int gooseId)
        {
            var goose = _context.Geese.FirstOrDefault(g => g.Id == gooseId && g.IsAlive);
            if (goose != null)
            {
                goose.FeatherProductionCount = (goose.FeatherProductionCount ?? 0) + 1;

                
                if (goose.FeatherProductionCount % 4 == 0)
                {
                    goose.Age += 1;
                }
                _context.SaveChanges();
            }
        }

        public int GetFeatherCount(int gooseId)
        {
            var goose = _context.Geese.FirstOrDefault(g => g.Id == gooseId && g.IsAlive);
            return goose?.FeatherProductionCount ?? 0;
        }

        public Goose? GetAliveGoose()
        {
            return _context.Geese.FirstOrDefault(g => g.IsAlive);
        }

        public void UpdateGooseGender(int gooseId, string gender)
        {
            var goose = _context.Geese.FirstOrDefault(g => g.Id == gooseId && g.IsAlive);
            if (goose != null)
            {
                goose.Gender = gender;
                _context.SaveChanges();
            }
        }
    }
}
