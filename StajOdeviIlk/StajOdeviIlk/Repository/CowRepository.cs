using StajOdeviIlk.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Repository
{
    public class CowRepository : ICowRepository
    {
        private readonly string _connectionString;

        public CowRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Cow cow)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Animals (SpeciesId, Age, Gender, Lifespan, IsAlive) VALUES (@SpeciesId, @Age, @Gender, @Lifespan, 1)", conn);
                cmd.Parameters.AddWithValue("@SpeciesId", cow.SpeciesId);
                cmd.Parameters.AddWithValue("@Age", cow.Age);
                cmd.Parameters.AddWithValue("@Gender", cow.Gender);
                cmd.Parameters.AddWithValue("@Lifespan", cow.Lifespan);
                cmd.ExecuteNonQuery();
            }
        }

        public Cow GetAliveCow()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT TOP 1 * FROM Animals WHERE SpeciesId = 2 AND IsAlive = 1", conn); // 2 = Cow
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cow
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Age = Convert.ToInt32(reader["Age"]),
                            Gender = reader["Gender"].ToString(),
                            SpeciesId = Convert.ToInt32(reader["SpeciesId"]),
                            Lifespan = Convert.ToInt32(reader["Lifespan"]),
                            IsAlive = Convert.ToBoolean(reader["IsAlive"])
                        };
                    }
                }
            }

            return null;
        }

        public void UpdateGender(int cowId, string gender)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Animals SET Gender = @Gender WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Id", cowId);
                cmd.ExecuteNonQuery();
            }
        }

        public void AgeUp(int cowId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Animals SET Age = Age + 1 WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", cowId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Kill(int cowId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Animals SET IsAlive = 0 WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", cowId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Product> GetProducts(int cowId)
        {
            var products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Products WHERE AnimalId = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", cowId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            AnimalId = cowId,
                            ProductTypeId = Convert.ToInt32(reader["ProductTypeId"]),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            ProductionDate = Convert.ToDateTime(reader["ProductionDate"]),
                            IsSold = Convert.ToBoolean(reader["IsSold"])
                        });
                    }
                }
            }

            return products;
        }
    }
}