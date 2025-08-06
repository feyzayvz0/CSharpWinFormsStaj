using StajOdeviIlkNet8.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace StajOdeviIlkNet8.Repository
{
    public interface IProductRepository
    {
        void Add(Product product);
        List<Product> GetProductsByAnimalId(int animalId);
        int GetUnsoldProductCount(int productTypeId);
        int SellProducts(int productTypeId, int quantityToSell);
        void MarkProductsAsSold(int productTypeId, int quantity);
    }

    public class ProductRepository(FarmDbContext context) : IProductRepository
    {
        private readonly FarmDbContext _context = context;

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetProductsByAnimalId(int animalId)
        {
            
            return [.. _context.Products.Where(p => p.AnimalId == animalId)];
        }

        public int GetUnsoldProductCount(int productTypeId)
        {
            return _context.Products
                .Where(p => p.ProductTypeId == productTypeId && !p.IsSold)
                .Sum(p => p.Quantity);
        }

        public int SellProducts(int productTypeId, int quantityToSell)
        {
            var unsoldProducts = _context.Products
                .Where(p => p.ProductTypeId == productTypeId && !p.IsSold)
                .OrderBy(p => p.Id)
                .ToList();

            int soldCount = 0;
            int leftToSell = quantityToSell;

            foreach (var product in unsoldProducts)
            {
                if (leftToSell <= 0) break;
                if (product.Quantity <= leftToSell)
                {
                    leftToSell -= product.Quantity;
                    product.IsSold = true;
                    soldCount += product.Quantity;
                }
               
            }

            _context.SaveChanges();
            return soldCount;
        }

        public void MarkProductsAsSold(int productTypeId, int quantity)
        {
            var unsoldProducts = _context.Products
                .Where(p => p.ProductTypeId == productTypeId && !p.IsSold)
                .OrderBy(p => p.Id)
                .Take(quantity)
                .ToList();

            foreach (var product in unsoldProducts)
            {
                product.IsSold = true;
            }

            _context.SaveChanges();
        }
    }
}
