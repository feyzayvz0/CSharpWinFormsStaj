using StajOdeviIlkNet8.Models;
using StajOdeviIlkNet8.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Repositories
{
    public interface IChickenRepository : IAnimalRepository
    {
        int GetEggCount(int animalId);
        void IncrementEggCount(int animalId);
     
        Chicken GetAliveChicken();
        

    }
}
