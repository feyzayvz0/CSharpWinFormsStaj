using StajOdeviIlk.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Repository
{
    public class ChickenRepository : AnimalRepository, IChickenRepository
    {
        private readonly string _connectionString;
        private readonly IAnimalRepository _animalRepository;

        public ChickenRepository(IAnimalRepository animalRepository, string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
            _animalRepository = animalRepository;
        }

        public void IncrementEggCount(int animalId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = "UPDATE Animals SET EggProductionCount = ISNULL(EggProductionCount, 0) + 1 WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", animalId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int GetEggCount(int animalId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var query = "SELECT ISNULL(EggProductionCount, 0) FROM Animals WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", animalId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
