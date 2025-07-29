using StajOdeviIlk.Helpers;
using StajOdeviIlk.Models;
using StajOdeviIlk.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public bool CanBuyAnimal(int speciesId)
        {
            return !_animalRepository.HasAnyAliveAnimal(speciesId);
        }

        public async Task<(bool IsSuccess, string Message)> BuyAnimalAsync(Animal animal, decimal price)
        {
            if (!DatabaseHelper.HasEnoughCash(price))
                return (false, "Yetersiz bakiye!");

            _animalRepository.AddAnimal(animal);
            DatabaseHelper.DeductCash(price);

            return (true, "Yeni hayvan başarıyla satın alındı.");
        }

        public int? GetAliveAnimalId(int speciesId)
        {
            return _animalRepository.GetAliveAnimalId(speciesId);
        }

        public int GetAnimalAge(int animalId)
        {
            return _animalRepository.GetAnimalAge(animalId);
        }

        public string GetAnimalGender(int animalId)
        {
            return _animalRepository.GetAnimalGender(animalId);
        }

        public void KillAnimal(int animalId)
        {
            _animalRepository.KillAnimal(animalId);
        }

        public void IncrementAge(int animalId)
        {
            _animalRepository.IncrementAge(animalId);
        }

        public async Task<(bool IsSuccess, bool AnimalDied, string Message)> FeedAnimalAsync(int speciesId, string gender)
        {
            var animalId = _animalRepository.GetAliveAnimalId(speciesId);
            if (animalId == null)
                return (false, false, "Canlı hayvan yok! Yeni bir hayvan satın alın.");

            string actualGender = _animalRepository.GetAnimalGender(animalId.Value);
            if (!string.Equals(actualGender, gender, StringComparison.OrdinalIgnoreCase))
                return (false, false, "Hayvanın cinsiyeti seçilenle uyuşmuyor.");

            // Ürün ekleme
            DatabaseHelper.AddProduct(animalId.Value, speciesId);

            // Yaşı artır
            _animalRepository.IncrementAge(animalId.Value);

            int age = _animalRepository.GetAnimalAge(animalId.Value);
            if (age >= 10)
            {
                _animalRepository.KillAnimal(animalId.Value);
                return (true, true, "Hayvan 10 yaşına ulaştı ve öldü.");
            }

            return (true, false, "Besleme ve ürün toplama başarılı.");
        }
    }
}