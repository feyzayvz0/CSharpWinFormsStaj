using StajOdeviIlkNet8.Models;
using StajOdeviIlkNet8.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StajOdeviIlkNet8.Services
{
    public class SheepService(ISheepRepository sheepRepository, IProductRepository productRepository, ICashRepository cashRepository)
    {
        private readonly ISheepRepository _sheepRepository = sheepRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICashRepository _cashRepository = cashRepository;

        public Sheep? GetAliveSheep()
        {
            return _sheepRepository.GetAliveSheep();
        }


        public bool HasAnyAliveSheep()
        {
            return _sheepRepository.HasAnyAliveAnimal(3);
        }

        public void BuySheep(string gender, decimal price)
        {
            if (!_cashRepository.HasEnoughCash(price))
                throw new InvalidOperationException("Yetersiz bakiye!");

            var sheep = new Sheep
            {
                Age = 1,
                Gender = gender,
                SpeciesId = 3,
                Lifespan = 10,
                IsAlive = true
            };

            _sheepRepository.AddAnimal(sheep);
            _cashRepository.DecreaseCash(price);
        }

        public bool ProduceWool()
        {
            var sheep = _sheepRepository.GetAliveSheep();
            if (sheep == null)
                return false;

        
            var wool = sheep.Produce();

            wool.AnimalId = sheep.Id;
            wool.ProductionDate = DateTime.Now;
            wool.IsSold = false;
            _productRepository.Add(wool);

         
            _sheepRepository.IncrementWoolCount(sheep.Id);

          
            int woolCount = _sheepRepository.GetWoolCount(sheep.Id);

         
            if (woolCount % 3 == 0)
            {
                _sheepRepository.IncrementAge(sheep.Id);
            }

           
            var age = _sheepRepository.GetAnimalAge(sheep.Id);
            if (age >= 10) 
            {
                _sheepRepository.KillAnimal(sheep.Id);
                return true; 
            }

            return false; 
        }


        public int GetUnsoldProductCount()
        {
            return _productRepository.GetUnsoldProductCount(3);
        }

        public int SellSheepProducts(int quantity, decimal unitPrice)
        {
            int soldCount = _productRepository.SellProducts(3, quantity);
            _cashRepository.AddCash(soldCount * unitPrice);
            return soldCount;
        }
        public decimal GetCash()
        {
            return _cashRepository.GetTotalCash();
        }


       
        public int GetSheepAgeById(int sheepId)
        {
            return _sheepRepository.GetSheepAgeById(sheepId);
        }


        public string? GetSheepGenderById(int sheepId)
        {
            return _sheepRepository.GetSheepGenderById(sheepId);
        }

        public int? GetAliveSheepId()
        {
            var sheep = GetAliveSheep();
            return sheep?.Id;
        }

    }
}
