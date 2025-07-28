using StajOdeviIlk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Repository
{
    public interface IAnimalRepository
    {
        List<AnimalSpecies> GetAnimalSpecies();
        void AddAnimal(Animal animal);
        Animal GetAliveAnimalBySpecies(int speciesId);
        void KillAnimal(int animalId);
        void IncrementAnimalAge(int animalId);
        int GetAnimalAge(int animalId);
        string GetAnimalGender(int animalId);
        void UpdateAnimalGender(int animalId, string gender);
        // Buraya türlere özel diğer işlemleri de ekle (örn. GetEggCount, IncrementWoolCount vs.)
    }
}