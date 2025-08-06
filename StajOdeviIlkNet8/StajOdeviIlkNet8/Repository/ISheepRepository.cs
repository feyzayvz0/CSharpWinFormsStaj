using StajOdeviIlkNet8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Repository
{
    public interface ISheepRepository : IAnimalRepository
    {
        void IncrementWoolCount(int sheepId);
        int GetWoolCount(int sheepId);
        Sheep? GetAliveSheep(); 
        new string? GetSheepGenderById(int sheepId);
        int GetSheepAgeById(int sheepId);
        
    }
}