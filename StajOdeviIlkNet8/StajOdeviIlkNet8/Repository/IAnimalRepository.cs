using StajOdeviIlkNet8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Repository
{
    public interface IAnimalRepository
    {
        void AddAnimal(Animal animal);
        void KillAnimal(int animalId);
        void IncrementAge(int animalId);
        int GetAnimalAge(int animalId);
        string? GetAnimalGender(int animalId);
        void UpdateAnimalGender(int animalId, string gender);

        bool HasAnyAliveAnimal(int speciesId);
        int? GetAliveAnimalId(int speciesId);
        string? GetSheepGenderById(int sheepId);
    }
}