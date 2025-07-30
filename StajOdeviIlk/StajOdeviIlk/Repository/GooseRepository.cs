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
    public class GooseRepository : AnimalRepository, IGooseRepository
    {
        private readonly string _connectionString;

        public GooseRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public void IncrementFeatherCount(int gooseId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                // Tüyü artır
                string updateFeatherQuery = "UPDATE Animals SET FeatherProductionCount = ISNULL(FeatherProductionCount, 0) + 1 WHERE Id = @id AND SpeciesId = 4";
                using (var featherCmd = new SqlCommand(updateFeatherQuery, conn))
                {
                    featherCmd.Parameters.AddWithValue("@id", gooseId);
                    featherCmd.ExecuteNonQuery();
                }

                // Son tüy sayısını al
                string selectQuery = "SELECT FeatherProductionCount FROM Animals WHERE Id = @id AND SpeciesId = 4";
                int count;
                using (var selectCmd = new SqlCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@id", gooseId);
                    count = Convert.ToInt32(selectCmd.ExecuteScalar());
                }

                // Her 3 tüyde bir yaş artır
                if (count % 3 == 0)
                {
                    string ageUpdateQuery = "UPDATE Animals SET Age = Age + 1 WHERE Id = @id AND SpeciesId = 4";
                    using (var ageCmd = new SqlCommand(ageUpdateQuery, conn))
                    {
                        ageCmd.Parameters.AddWithValue("@id", gooseId);
                        ageCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public int GetFeatherCount(int gooseId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT ISNULL(FeatherProductionCount, 0) FROM Animals WHERE Id = @id AND SpeciesId = 4";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", gooseId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public Goose GetAliveGoose()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT TOP 1 * FROM Animals WHERE SpeciesId = 4 AND IsAlive = 1", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Goose
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

        public void UpdateGooseGender(int gooseId, string gender)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "UPDATE Animals SET Gender = @Gender WHERE Id = @Id AND SpeciesId = 4";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", gooseId);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}