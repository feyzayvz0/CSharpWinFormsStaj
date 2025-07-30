using StajOdeviIlk.Models;
using StajOdeviIlk.Repositories;
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
        private readonly ICashRepository _cashRepository;

        public AnimalService(IAnimalRepository animalRepository, ICashRepository cashRepository)
        {
            _animalRepository = animalRepository;
            _cashRepository = cashRepository;
        }

        public bool CanBuyAnimal(int speciesId)
        {
            return !_animalRepository.HasAnyAliveAnimal(speciesId);
        }

        public Task<(bool IsSuccess, string Message)> BuyAnimalAsync(Animal animal, decimal price)
        {
            if (!_cashRepository.HasEnoughCash(price))
                return Task.FromResult((false, "Yetersiz bakiye!"));

            _animalRepository.AddAnimal(animal);
            _cashRepository.DecreaseCash(price);

            return Task.FromResult((true, "Yeni hayvan başarıyla satın alındı."));
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

        public Task<(bool IsSuccess, bool AnimalDied, string Message)> FeedAnimalAsync(int speciesId, string gender)
        {
            var animalId = _animalRepository.GetAliveAnimalId(speciesId);
            if (animalId == null)
                return Task.FromResult((false, false, "Canlı hayvan yok! Yeni bir hayvan satın alın."));

            string actualGender = _animalRepository.GetAnimalGender(animalId.Value);
            if (!string.Equals(actualGender, gender, StringComparison.OrdinalIgnoreCase))
                return Task.FromResult((false, false, "Hayvanın cinsiyeti seçilenle uyuşmuyor."));

            _animalRepository.IncrementAge(animalId.Value);

            int age = _animalRepository.GetAnimalAge(animalId.Value);
            if (age >= 10)
            {
                _animalRepository.KillAnimal(animalId.Value);
                return Task.FromResult((true, true, "Hayvan 10 yaşına ulaştı ve öldü."));
            }

            return Task.FromResult((true, false, "Besleme ve ürün toplama başarılı."));
        }

    }
}
