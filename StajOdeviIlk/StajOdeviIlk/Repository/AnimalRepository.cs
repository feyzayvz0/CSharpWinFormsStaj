using StajOdeviIlk.Helpers;
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
        private string _connectionString = DatabaseHelper.ConnectionString;

        public List<AnimalSpecies> GetAnimalSpecies()
        {
            List<AnimalSpecies> speciesList = new List<AnimalSpecies>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM AnimalSpecies", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    speciesList.Add(new AnimalSpecies
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }

            return speciesList;
        }

        public void AddAnimal(Animal animal)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Animals (SpeciesId, Age, Gender, Lifespan, IsAlive) VALUES (@SpeciesId, @Age, @Gender, @Lifespan, 1)", conn);
                cmd.Parameters.AddWithValue("@SpeciesId", animal.SpeciesId);
                cmd.Parameters.AddWithValue("@Age", animal.Age);
                cmd.Parameters.AddWithValue("@Gender", animal.Gender);
                cmd.Parameters.AddWithValue("@Lifespan", animal.Lifespan);
                cmd.ExecuteNonQuery();
            }
        }

        public Animal GetAliveAnimalBySpecies(int speciesId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Animals WHERE SpeciesId = @SpeciesId AND IsAlive = 1", conn);
                cmd.Parameters.AddWithValue("@SpeciesId", speciesId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Animal
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        SpeciesId = speciesId,
                        Age = reader.GetInt32(reader.GetOrdinal("Age")),
                        Gender = reader.GetString(reader.GetOrdinal("Gender")),
                        Lifespan = reader.GetInt32(reader.GetOrdinal("Lifespan")),
                        IsAlive = reader.GetBoolean(reader.GetOrdinal("IsAlive"))
                    };
                }
            }

            return null;
        }

        public void KillAnimal(int animalId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Animals SET IsAlive = 0 WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", animalId);
                cmd.ExecuteNonQuery();
            }
        }

        public void IncrementAnimalAge(int animalId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Animals SET Age = Age + 1 WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", animalId);
                cmd.ExecuteNonQuery();
            }
        }

        public int GetAnimalAge(int animalId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Age FROM Animals WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", animalId);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public string GetAnimalGender(int animalId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Gender FROM Animals WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", animalId);
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        public void UpdateAnimalGender(int animalId, string gender)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Animals SET Gender = @Gender WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Id", animalId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}