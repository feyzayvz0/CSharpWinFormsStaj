using StajOdeviIlk.Models;
using StajOdeviIlk.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Services
{
    public class GooseService
    {
        private readonly IGooseRepository _gooseRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICashRepository _cashRepository;

        public GooseService(IGooseRepository gooseRepository, IProductRepository productRepository, ICashRepository cashRepository)
        {
            _gooseRepository = gooseRepository;
            _productRepository = productRepository;
            _cashRepository = cashRepository;
        }

        public bool HasAnyAliveGoose()
        {
            return _gooseRepository.HasAnyAliveAnimal(4);
        }

        public void BuyGoose(string gender, decimal price)
        {
            if (!_cashRepository.HasEnoughCash(price))
                throw new InvalidOperationException("Yetersiz bakiye!");

            var goose = new Goose
            {
                Age = 1,
                Gender = gender,
                SpeciesId = 4,
                Lifespan = 10,
                IsAlive = true
            };

            _gooseRepository.AddAnimal(goose);
            _cashRepository.DecreaseCash(price);
        }

        public bool FeedGoose()
        {
            var goose = _gooseRepository.GetAliveGoose();
            if (goose == null) return false;

           
            var feather = goose.Produce();
            feather.Quantity = 1;
            feather.AnimalId = goose.Id;
            feather.ProductionDate = DateTime.Now;
            feather.IsSold = false;
            _productRepository.Add(feather);

           
            _gooseRepository.IncrementFeatherCount(goose.Id);

           
            int age = _gooseRepository.GetAnimalAge(goose.Id);
            if (age >= 10)
            {
                _gooseRepository.KillAnimal(goose.Id);
                return true; 
            }
            return false;
        }

        public int GetUnsoldProductCount()
        {
            return _productRepository.GetUnsoldProductCount(4);
        }

        public int SellGooseProducts(int quantity, decimal unitPrice)
        {
            int soldCount = _productRepository.SellProducts(4, quantity);
            _cashRepository.AddCash(soldCount * unitPrice);
            return soldCount;
        }

        public void UpdateGooseGender(int gooseId, string gender)
        {
            _gooseRepository.UpdateGooseGender(gooseId, gender);
        }

        public decimal GetCash()
        {
            return _cashRepository.GetTotalCash();
        }
        public Goose GetAliveGoose()
        {
            return _gooseRepository.GetAliveGoose();
        }
        public int GetFeatherCount(int gooseId)
        {
            return _gooseRepository.GetFeatherCount(gooseId);
        }


    }
}