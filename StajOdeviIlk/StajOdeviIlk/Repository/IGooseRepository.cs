using StajOdeviIlk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StajOdeviIlk.Repository
{
    public interface IGooseRepository : IAnimalRepository
    {
        void IncrementFeatherCount(int gooseId);
        int GetFeatherCount(int gooseId);
        Goose GetAliveGoose();
        void UpdateGooseGender(int gooseId, string gender);
    }
}