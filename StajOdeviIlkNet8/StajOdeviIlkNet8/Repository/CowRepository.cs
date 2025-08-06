using StajOdeviIlkNet8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StajOdeviIlkNet8.Repository
{
    public class CowRepository(FarmDbContext context) : ICowRepository
    {
        private readonly FarmDbContext _context = context;

        public void Add(Cow cow)
        {
            _context.Cows.Add(cow);
            _context.SaveChanges();
        }

        public Cow? GetAliveCow()
        {
            return _context.Cows.FirstOrDefault(c => c.IsAlive);
        }


        public void UpdateGender(int cowId, string gender)
        {
            var cow = _context.Cows.Find(cowId);
            if (cow != null)
            {
                cow.Gender = gender;
                _context.SaveChanges();
            }
        }

        public void AgeUp(int cowId)
        {
            var cow = _context.Cows.Find(cowId);
            if (cow != null)
            {
                cow.Age += 1;
                _context.SaveChanges();
            }
        }

        public void IncrementAge(int cowId)
        {
            AgeUp(cowId); 
        }

        public void Kill(int cowId)
        {
            var cow = _context.Cows.Find(cowId);
            if (cow != null)
            {
                cow.IsAlive = false;
                _context.SaveChanges();
            }
        }

        public List<Product> GetProducts(int cowId)
        {
            return [.. _context.Products.Where(p => p.AnimalId == cowId)];
        }

        public void IncrementMilkCount(int cowId)
        {
            var cow = _context.Cows.Find(cowId);
            if (cow != null)
            {
                cow.MilkProductionCount = (cow.MilkProductionCount ?? 0) + 1;
                _context.SaveChanges();
            }
        }

        public int GetMilkCount(int cowId)
        {
            var cow = _context.Cows.Find(cowId);
            return cow?.MilkProductionCount ?? 0;
        }

        public int GetAnimalAge(int cowId)
        {
            var cow = _context.Cows.Find(cowId);
            return cow?.Age ?? 0;
        }
    }
}
