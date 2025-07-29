using StajOdeviIlk.Models;
using StajOdeviIlk.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StajOdeviIlk.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICashRepository _cashRepository;

        public ProductService(IProductRepository productRepository, ICashRepository cashRepository)
        {
            _productRepository = productRepository;
            _cashRepository = cashRepository;
        }

        public int GetUnsoldProductCount(int productTypeId)
        {
            return _productRepository.GetUnsoldProductCount(productTypeId);
        }

        public void SellProduct(int productTypeId, int quantity)
        {
            _productRepository.MarkProductsAsSold(productTypeId, quantity);
            decimal totalEarned = quantity * GetUnitPrice(productTypeId);
            _cashRepository.AddCash(totalEarned);
        }

        private decimal GetUnitPrice(int productTypeId)
        {
            switch (productTypeId)
            {
                case 1: return 5m;
                case 2: return 10m;
                case 3: return 30m;
                case 4: return 20m;
                default: return 0m;
            }
        }
    }
} 