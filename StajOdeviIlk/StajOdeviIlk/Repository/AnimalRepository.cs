
using StajOdeviIlk.Models;
using StajOdeviIlk.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly string _connectionString;

        public AnimalRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddAnimal(Animal animal)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Animals (SpeciesId, Age, Gender, Lifespan, IsAlive) VALUES (@SpeciesId, @Age, @Gender, @Lifespan, 1)", conn);
                cmd.Parameters.AddWithValue("@SpeciesId", animal.SpeciesId);
                cmd.Parameters.AddWithValue("@Age", animal.Age);
                cmd.Parameters.AddWithValue("@Gender", animal.Gender);
                cmd.Parameters.AddWithValue("@Lifespan", animal.Lifespan);
                cmd.ExecuteNonQuery();
            }
        }
        public void KillAnimal(int animalId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Animals SET IsAlive = 0 WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", animalId);
                cmd.ExecuteNonQuery();
            }
        }

        public void IncrementAge(int animalId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Animals SET Age = Age + 1 WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", animalId);
                cmd.ExecuteNonQuery();
            }
        }

        public int GetAnimalAge(int animalId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Age FROM Animals WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", animalId);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public string GetAnimalGender(int animalId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Gender FROM Animals WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", animalId);
                return cmd.ExecuteScalar()?.ToString();
            }
        }

        public void UpdateAnimalGender(int animalId, string gender)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Animals SET Gender = @Gender WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Id", animalId);
                cmd.ExecuteNonQuery();
            }
        }

        public bool HasAnyAliveAnimal(int speciesId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT COUNT(*) FROM Animals WHERE SpeciesId = @SpeciesId AND IsAlive = 1", conn);
                cmd.Parameters.AddWithValue("@SpeciesId", speciesId);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public int? GetAliveAnimalId(int speciesId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT TOP 1 Id FROM Animals WHERE SpeciesId = @SpeciesId AND IsAlive = 1", conn);
                cmd.Parameters.AddWithValue("@SpeciesId", speciesId);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : (int?)null;
            }
        }
    }
}
