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
    public class CowService
    {
        private readonly ICowRepository _cowRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICashRepository _cashRepository;

        public CowService(ICowRepository cowRepository, IProductRepository productRepository, ICashRepository cashRepository)
        {
            _cowRepository = cowRepository;
            _productRepository = productRepository;
            _cashRepository = cashRepository;
        }

        public int SellCowProducts(int quantity, decimal unitPrice)
        {
            int soldCount = _productRepository.SellProducts(2, quantity);
            _cashRepository.AddCash(soldCount * unitPrice);
            return soldCount;
        }

        public int GetUnsoldProductCount()
        {
            return _productRepository.GetUnsoldProductCount(2);
        }

        public void BuyCow(string gender, decimal price)
        {
            if (!_cashRepository.HasEnoughCash(price))
                throw new InvalidOperationException("Yetersiz bakiye!");

            var cow = new Cow
            {
                SpeciesId = 2,
                Age = 1,
                Gender = gender,
                Lifespan = 10,
                IsAlive = true
            };

            _cowRepository.Add(cow);
            _cashRepository.DecreaseCash(price);
        }

        public Cow GetAliveCow()
        {
            return _cowRepository.GetAliveCow();
        }

     

        public List<Product> GetCowProducts()
        {
            var cow = _cowRepository.GetAliveCow();
            if (cow == null) return new List<Product>();

            return _cowRepository.GetProducts(cow.Id);
        }

        public void UpdateGender(int cowId, string gender)
        {
            _cowRepository.UpdateGender(cowId, gender);
        }

        public decimal GetCash()
        {
            return _cashRepository.GetTotalCash();
        }
        public bool ProduceMilk()
        {
            var cow = _cowRepository.GetAliveCow();
            if (cow == null)
                return false;

          
            var milk = cow.Produce(); 
            milk.AnimalId = cow.Id;
            milk.ProductionDate = DateTime.Now;
            milk.IsSold = false;
            _productRepository.Add(milk);

           
            _cowRepository.IncrementMilkCount(cow.Id);

         
            int milkCount = _cowRepository.GetMilkCount(cow.Id);
            if (milkCount % 2 == 0)
                _cowRepository.IncrementAge(cow.Id);

            int age = _cowRepository.GetAnimalAge(cow.Id);
            if (age >= 15)
            {
                _cowRepository.Kill(cow.Id);
                return false;
            }

            return true; 
        }


    }
}
