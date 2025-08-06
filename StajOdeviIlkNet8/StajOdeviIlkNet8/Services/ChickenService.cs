using StajOdeviIlkNet8.Models;
using StajOdeviIlkNet8.Repositories;
using StajOdeviIlkNet8.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Services
{
    public class ChickenService(
        IChickenRepository chickenRepository,
        IProductRepository productRepository,
        ICashRepository cashRepository)
    {
        private readonly IChickenRepository _chickenRepository = chickenRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICashRepository _cashRepository = cashRepository;

        public bool FeedChicken()
        {
            int? chickenId = _chickenRepository.GetAliveAnimalId(1); 
            if (!chickenId.HasValue)
                return false; 

            
            var product = new Product
            {
                AnimalId = chickenId.Value,
                ProductTypeId = 1, 
                Quantity = 1,
                ProductionDate = DateTime.Now,
                IsSold = false
            };
            _productRepository.Add(product);

         
            _chickenRepository.IncrementEggCount(chickenId.Value);

           
            int eggCount = _chickenRepository.GetEggCount(chickenId.Value);
            if (eggCount % 5 == 0)
            {
                _chickenRepository.IncrementAge(chickenId.Value);
            }

            
            int age = _chickenRepository.GetAnimalAge(chickenId.Value);
            if (age >= 5)
            {
                _chickenRepository.KillAnimal(chickenId.Value);
                return false; 
            }

            return true; 
        }


        
        public void BuyChicken(decimal price)
        {
            if (!_cashRepository.HasEnoughCash(price))
                throw new InvalidOperationException("Yetersiz bakiye!");

            var chicken = new Chicken
            {
                Age = 1,
                Gender = "Dişi",
                SpeciesId = 1, 
                Lifespan = 10
            };

            _chickenRepository.AddAnimal(chicken);
            _cashRepository.DecreaseCash(price);
        }

      
        public int GetUnsoldProductCount()
        {
            return _productRepository.GetUnsoldProductCount(1); 
        }

        public int SellChickenProducts(int quantity, decimal unitPrice)
        {
            int soldCount = _productRepository.SellProducts(1, quantity); 
            _cashRepository.AddCash(soldCount * unitPrice);
            return soldCount;
        }

        
        public decimal GetCash()
        {
            return _cashRepository.GetTotalCash();
        }

        
        public bool HasAnyAliveChicken()
        {
            return _chickenRepository.HasAnyAliveAnimal(1); 
        }

        public bool HasEnoughCash(decimal amount)
        {
            return _cashRepository.HasEnoughCash(amount);
        }

        public Chicken GetAliveChicken()
        {
            return _chickenRepository.GetAliveChicken();
        }

    }
}