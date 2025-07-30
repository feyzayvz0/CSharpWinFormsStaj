using StajOdeviIlk.Models;
using StajOdeviIlk.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StajOdeviIlk.Services
{
    public class SheepService
    {
        private readonly ISheepRepository _sheepRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICashRepository _cashRepository;

        public SheepService(ISheepRepository sheepRepository, IProductRepository productRepository, ICashRepository cashRepository)
        {
            _sheepRepository = sheepRepository;
            _productRepository = productRepository;
            _cashRepository = cashRepository;
        }
        public Sheep GetAliveSheep()
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

            // 1. Yün üret ve Product tablosuna ekle
            var wool = sheep.Produce();
            wool.AnimalId = sheep.Id;
            wool.ProductionDate = DateTime.Now;
            wool.IsSold = false;
            _productRepository.Add(wool);

            // 2. WoolProductionCount artır
            _sheepRepository.IncrementWoolCount(sheep.Id);

            // 3. WoolProductionCount çek
            int woolCount = _sheepRepository.GetWoolCount(sheep.Id);

            // 4. Her 2 yünde bir yaş artır!
            if (woolCount % 2 == 0)
            {
                _sheepRepository.IncrementAge(sheep.Id);
            }

            // 5. Yaşı güncel olarak kontrol et (test için 35!)
            var age = _sheepRepository.GetAnimalAge(sheep.Id);
            if (age >= 35) // <-- Burada değiştirdin
            {
                _sheepRepository.KillAnimal(sheep.Id);
                return true; // Koyun öldü
            }

            return false; // Koyun yaşıyor
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


        // Id'ye göre yaş döndürür
        public int GetSheepAgeById(int sheepId)
        {
            return _sheepRepository.GetSheepAgeById(sheepId);
        }

        // Id'ye göre cinsiyet döndürür
        public string GetSheepGenderById(int sheepId)
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
