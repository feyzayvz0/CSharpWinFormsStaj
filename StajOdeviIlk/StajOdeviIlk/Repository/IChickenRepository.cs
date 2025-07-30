using StajOdeviIlk.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Repositories
{
    public interface IChickenRepository : IAnimalRepository
    {
        int GetEggCount(int animalId);
        void IncrementEggCount(int animalId);
    }
}
