using StajOdeviIlk.Models;
using StajOdeviIlk.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Repository
{
    public class SheepRepository : AnimalRepository, ISheepRepository
    {
        private readonly string _connectionString;

        public SheepRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public void IncrementWoolCount(int sheepId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "UPDATE Animals SET WoolProductionCount = ISNULL(WoolProductionCount, 0) + 1 WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", sheepId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int GetWoolCount(int sheepId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT ISNULL(WoolProductionCount, 0) FROM Animals WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", sheepId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public Sheep GetAliveSheep()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT TOP 1 * FROM Animals WHERE SpeciesId = 3 AND IsAlive = 1", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Sheep
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            SpeciesId = Convert.ToInt32(reader["SpeciesId"]),
                            Age = Convert.ToInt32(reader["Age"]),
                            Gender = reader["Gender"].ToString(),
                            Lifespan = Convert.ToInt32(reader["Lifespan"]),
                            IsAlive = Convert.ToBoolean(reader["IsAlive"])
                        };
                    }
                }
            }

            return null;
        }
        public int? GetAliveSheepId()
        {
            var sheep = GetAliveSheep();
            return sheep?.Id;
        }

        public int GetSheepAgeById(int sheepId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Age FROM Animals WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", sheepId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        

        public string GetSheepGenderById(int sheepId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Gender FROM Animals WHERE Id = @Id AND SpeciesId = 3";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", sheepId);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

    }
}