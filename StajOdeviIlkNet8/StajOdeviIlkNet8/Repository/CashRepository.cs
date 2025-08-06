using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StajOdeviIlkNet8.Repository;
using StajOdeviIlkNet8.Models;

namespace StajOdeviIlkNet8.Repositories
{
    public class CashRepository : ICashRepository
    {
        private readonly FarmDbContext _context;

        public CashRepository(FarmDbContext context)
        {
            _context = context;
        }

        public void AddCash(decimal amount)
        {
            var cashRegister = new CashRegister
            {
                Amount = amount,
                Date = DateTime.Now
            };
            _context.CashRegisters.Add(cashRegister);
            _context.SaveChanges();
        }

        public void DecreaseCash(decimal amount)
        {
            var cashRegister = new CashRegister
            {
                Amount = -amount,
                Date = DateTime.Now
            };
            _context.CashRegisters.Add(cashRegister);
            _context.SaveChanges();
        }

        public decimal GetTotalCash()
        {
            return _context.CashRegisters.Sum(cr => cr.Amount);
        }

        public bool HasEnoughCash(decimal amount)
        {
            return GetTotalCash() >= amount;
        }
    }
}
