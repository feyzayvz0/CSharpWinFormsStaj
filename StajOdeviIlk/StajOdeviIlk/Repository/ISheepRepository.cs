using StajOdeviIlk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Repository
{
    public interface ISheepRepository : IAnimalRepository
    {
        void IncrementWoolCount(int sheepId);
        int GetWoolCount(int sheepId);
        Sheep GetAliveSheep();

        string GetSheepGenderById(int sheepId);
        int GetSheepAgeById(int sheepId);
        
    }
}