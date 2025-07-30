using StajOdeviIlk.Models;
using StajOdeviIlk.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Services
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
            int soldCount = _productRepository.SellProducts(2, quantity); // 2: süt
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
                Lifespan = 10, // 10 yaşında ölecek!
                IsAlive = true
            };

            _cowRepository.Add(cow);
            _cashRepository.DecreaseCash(price);
        }

        public Cow GetAliveCow()
        {
            return _cowRepository.GetAliveCow();
        }

        /// <summary>
        /// Süt üretimi - her 2 üretimde yaş +1, 10 yaşında ölüm!
        /// </summary>
        public bool ProduceMilk()
        {
            var cow = _cowRepository.GetAliveCow();
            if (cow == null)
                return false;

            // 1. Sütü üret, Product'a ekle
            var milk = cow.Produce();
            milk.AnimalId = cow.Id;
            milk.ProductionDate = DateTime.Now;
            milk.IsSold = false;
            _productRepository.Add(milk);

            // 2. Süt sayısını ve gerekiyorsa yaşı artır
            _cowRepository.IncrementMilkCount(cow.Id); // Her 2 süt = yaş +1 (bu işlemi repositoryde ayarladık!)

            // 3. Yaşı çek ve ölüm kontrolü
            int age = _cowRepository.GetAnimalAge(cow.Id);
            if (age >= 10)
            {
                _cowRepository.Kill(cow.Id);
                return true; // öldü
            }
            return false; // yaşıyor
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
    }
}
