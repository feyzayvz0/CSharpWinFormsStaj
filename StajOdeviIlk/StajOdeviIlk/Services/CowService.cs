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

        public CowService(ICowRepository cowRepository, IProductRepository productRepository)
        {
            _cowRepository = cowRepository;
            _productRepository = productRepository;
        }

        public void BuyCow(string gender)
        {
            var cow = new Cow
            {
                SpeciesId = 2, // Cow
                Age = 0,
                Gender = gender,
                Lifespan = 12,
                IsAlive = true
            };

            _cowRepository.Add(cow);
        }

        public Cow GetAliveCow()
        {
            return _cowRepository.GetAliveCow();
        }

        public void FeedCow()
        {
            var cow = _cowRepository.GetAliveCow();
            if (cow == null) return;

            _cowRepository.AgeUp(cow.Id);

            cow.Age++;
            if (cow.Age >= cow.Lifespan)
            {
                _cowRepository.Kill(cow.Id);
            }
        }

        public Product Produce()
        {
            var cow = _cowRepository.GetAliveCow();
            if (cow == null) return null;

            return cow.Produce(); // Bu sadece Product nesnesi döner, DB’ye ekleme işlemi yapılmaz!
        }

        public Product ProduceAndSave()
        {
            var cow = _cowRepository.GetAliveCow();
            if (cow == null) return null;

            var product = cow.Produce(); // Product nesnesi oluşturur
            if (product != null)
            {
                product.AnimalId = cow.Id; // Ürünü ilgili hayvan ile ilişkilendir
                product.ProductionDate = DateTime.Now;
                _productRepository.Add(product); // Ürünü DB'ye ekle
            }
            return product;
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
