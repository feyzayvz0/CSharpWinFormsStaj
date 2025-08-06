using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StajOdeviIlkNet8.Repository
{
    public interface ICashRepository
    {
        void AddCash(decimal amount);
        void DecreaseCash(decimal amount);
        decimal GetTotalCash();
        bool HasEnoughCash(decimal amount);
    }
}
