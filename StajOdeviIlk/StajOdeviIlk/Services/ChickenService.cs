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
    public class ChickenService
    {
        private readonly IChickenRepository _chickenRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICashRepository _cashRepository;

        public ChickenService(
            IChickenRepository chickenRepository,
            IProductRepository productRepository,
            ICashRepository cashRepository)
        {
            _chickenRepository = chickenRepository;
            _productRepository = productRepository;
            _cashRepository = cashRepository;
        }

        /// <summary>
        /// Tavuğu besler, yumurta üretir, yaşını artırır ve gerekiyorsa öldürür.
        /// </summary>
        public bool FeedChicken()
        {
            int? chickenId = _chickenRepository.GetAliveAnimalId(1); // 1 = Chicken
            if (!chickenId.HasValue)
                return false; // Canlı tavuk yok!

            // Yeni ürün (yumurta) oluştur ve kaydet
            var product = new Product
            {
                AnimalId = chickenId.Value,
                ProductTypeId = 1, // 1 = Yumurta
                Quantity = 1,
                ProductionDate = DateTime.Now,
                IsSold = false
            };
            _productRepository.Add(product);

            // Yumurtlama sayısını artır
            _chickenRepository.IncrementEggCount(chickenId.Value);

            // Her 2 yumurtada bir yaş artır
            int eggCount = _chickenRepository.GetEggCount(chickenId.Value);
            if (eggCount % 2 == 0)
            {
                _chickenRepository.IncrementAge(chickenId.Value);
            }

            // Yaş kontrolü
            int age = _chickenRepository.GetAnimalAge(chickenId.Value);
            if (age >= 5)
            {
                _chickenRepository.KillAnimal(chickenId.Value);
                return false; // Tavuk öldü!
            }

            return true; // Tavuk yaşıyor!
        }


        /// <summary>
        /// Yeni tavuk satın alır, bakiyeden düşer.
        /// </summary>
        public void BuyChicken(decimal price)
        {
            if (!_cashRepository.HasEnoughCash(price))
                throw new InvalidOperationException("Yetersiz bakiye!");

            var chicken = new Chicken
            {
                Age = 1,
                Gender = "Dişi",
                SpeciesId = 1, // 1 = Chicken
                Lifespan = 100
            };

            _chickenRepository.AddAnimal(chicken);
            _cashRepository.DecreaseCash(price);
        }

        /// <summary>
        /// Satılmamış yumurta sayısını döner.
        /// </summary>
        public int GetUnsoldProductCount()
        {
            return _productRepository.GetUnsoldProductCount(1); // 1 = Yumurta
        }

        /// <summary>
        /// Tavuk ürünlerini satar ve kasaya gelir ekler.
        /// </summary>
        public int SellChickenProducts(int quantity, decimal unitPrice)
        {
            int soldCount = _productRepository.SellProducts(1, quantity); // 1 = Yumurta
            _cashRepository.AddCash(soldCount * unitPrice);
            return soldCount;
        }

        /// <summary>
        /// Kasa bakiyesini döner.
        /// </summary>
        public decimal GetCash()
        {
            return _cashRepository.GetTotalCash();
        }

        /// <summary>
        /// Canlı tavuk olup olmadığını kontrol eder.
        /// </summary>
        public bool HasAnyAliveChicken()
        {
            return _chickenRepository.HasAnyAliveAnimal(1); // 1 = Chicken
        }

        /// <summary>
        /// Belirtilen miktarda paranın olup olmadığını kontrol eder.
        /// </summary>
        public bool HasEnoughCash(decimal amount)
        {
            return _cashRepository.HasEnoughCash(amount);
        }
    }
}