using StajOdeviIlk.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Repository
{
    public interface IProductRepository
    {
        void Add(Product product);
        List<Product> GetProductsByAnimalId(int animalId);
        int GetUnsoldProductCount(int productTypeId);
        int SellProducts(int productTypeId, int quantityToSell);
        void MarkProductsAsSold(int productTypeId, int quantity);

    }

    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Products (AnimalId, ProductTypeId, Quantity, ProductionDate, IsSold) 
                                 VALUES (@AnimalId, @ProductTypeId, @Quantity, @ProductionDate, 0)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AnimalId", product.AnimalId);
                    cmd.Parameters.AddWithValue("@ProductTypeId", product.ProductTypeId);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@ProductionDate", product.ProductionDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetProductsByAnimalId(int animalId)
        {
            var products = new List<Product>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Products WHERE AnimalId = @AnimalId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AnimalId", animalId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                AnimalId = animalId,
                                ProductTypeId = Convert.ToInt32(reader["ProductTypeId"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                ProductionDate = Convert.ToDateTime(reader["ProductionDate"]),
                                IsSold = Convert.ToBoolean(reader["IsSold"])
                            });
                        }
                    }
                }
            }
            return products;
        }

        public int GetUnsoldProductCount(int productTypeId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT ISNULL(SUM(Quantity), 0) FROM Products WHERE ProductTypeId = @ProductTypeId AND IsSold = 0";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int SellProducts(int productTypeId, int quantityToSell)
        {
            // Basit bir örnek: Satılacak ürün sayısı kadar IsSold'u 1 yap
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"
                UPDATE TOP(@QuantityToSell) Products
                SET IsSold = 1
                WHERE ProductTypeId = @ProductTypeId AND IsSold = 0";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@QuantityToSell", quantityToSell);
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public void MarkProductsAsSold(int productTypeId, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
            UPDATE TOP (@Quantity) Products
            SET IsSold = 1
            WHERE ProductTypeId = @ProductTypeId AND IsSold = 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}