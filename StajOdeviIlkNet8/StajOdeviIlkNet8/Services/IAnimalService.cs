using StajOdeviIlkNet8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Services
{
    public interface IAnimalService
    {
        bool CanBuyAnimal(int speciesId);
        Task<(bool IsSuccess, string Message)> BuyAnimalAsync(Animal animal, decimal price);
        int? GetAliveAnimalId(int speciesId);
        int GetAnimalAge(int animalId);
        string? GetAnimalGender(int animalId);
        void KillAnimal(int animalId);
        void IncrementAge(int animalId);
        Task<(bool IsSuccess, bool AnimalDied, string Message)> FeedAnimalAsync(int speciesId, string gender);
    }
}