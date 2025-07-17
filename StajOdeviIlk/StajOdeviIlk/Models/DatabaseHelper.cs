using StajOdeviIlk.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StajOdeviIlk.Helpers
{
    public static class DatabaseHelper
    {
        public static string ConnectionString = @"Data Source=FEYZA;Initial Catalog=StajOdeviIlk;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        // 🐮 Tür Listesi
        public static List<AnimalSpecies> GetAnimalSpecies()
        {
            List<AnimalSpecies> speciesList = new List<AnimalSpecies>();

            using (SqlConnection conn = GetConnection())
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

        // 🐔 Hayvan Ekle
        public static void AddAnimal(Animal animal)
        {
            if (animal.SpeciesId == 2 && HasAnyAliveChicken()) return; // Tavuksa ve zaten canlı varsa ekleme

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Animals (SpeciesId, Age, Gender, Lifespan, IsAlive) VALUES (@SpeciesId, @Age, @Gender, @Lifespan, 1)", conn);

                cmd.Parameters.AddWithValue("@SpeciesId", animal.SpeciesId);
                cmd.Parameters.AddWithValue("@Age", animal.Age);
                cmd.Parameters.AddWithValue("@Gender", animal.Gender);
                cmd.Parameters.AddWithValue("@Lifespan", 100); // Sabit ömür

                cmd.ExecuteNonQuery();
            }
        }

        // 🐣 Canlı Tavuk ID’si getir
        public static int GetAliveChickenId()
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT TOP 1 Id FROM Animals WHERE SpeciesId = 2 AND IsAlive = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                return result != null ? Convert.ToInt32(result) : -1;
            }
        }


        public static void AddProduct(int animalId, int productTypeId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

               
                string insertQuery = @"
            INSERT INTO Products (AnimalId, ProductTypeId, Quantity, ProductionDate, IsSold)
            VALUES (@AnimalId, @ProductTypeId, 1, GETDATE(), 0)";
                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@AnimalId", animalId);
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int GetAliveChickenCount()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Animals WHERE SpeciesId = 2 AND IsAlive = 1";
                using (var cmd = new SqlCommand(query, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }


        // 📦 Satılmamış ürün sayısı
        public static int GetUnsoldProductCount(int productTypeId)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Products WHERE ProductTypeId = @ProductTypeId AND IsSold = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId);

                return (int)cmd.ExecuteScalar();
            }
        }

        // 🛒 Ürünleri sat, satış adedi döndür
        public static int SellProducts(int ProductTypeId, int quantity)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string query = @"
            UPDATE TOP (@Quantity) Products
            SET IsSold = 1
            WHERE ProductTypeId = @ProductTypeId AND IsSold = 0";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@ProductTypeId", ProductTypeId);

                    return cmd.ExecuteNonQuery(); // Satılan ürün sayısı
                }
            }
        }

        // 💰 Kasa: Para Ekle
        public static void AddCash(decimal amount)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CashRegister (Amount) VALUES (@Amount)", conn);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.ExecuteNonQuery();
            }
        }

        // 💸 Kasa: Para Düş
        public static void DeductCash(decimal amount)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO CashRegister (Amount) VALUES (@Amount)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Amount", -amount); // NEGATİF değer!
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // 🧮 Kasada yeterli para var mı?
        public static bool HasEnoughCash(decimal amount)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT SUM(Amount) FROM CashRegister";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                decimal totalCash = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                return totalCash >= amount;
            }
        }

        // 💰 Toplam Kasa Değerini Döndür (İstatistik için)
        public static decimal GetTotalCash()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT ISNULL(SUM(Amount), 0) FROM CashRegister";
                using (var cmd = new SqlCommand(query, conn))
                {
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }
        public static bool HasAnyAliveChicken()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Animals WHERE SpeciesId = 2 AND IsAlive = 1";
                using (var cmd = new SqlCommand(query, conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public static int GetAnimalAge(int animalId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT Age FROM Animals WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", animalId);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }
        public static void IncrementEggCount(int animalId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "UPDATE Animals SET EggProductionCount = ISNULL(EggProductionCount, 0) + 1 WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", animalId);
                cmd.ExecuteNonQuery();
            }
        }

        public static int GetEggCount(int animalId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT ISNULL(EggProductionCount, 0) FROM Animals WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", animalId);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static void IncrementAnimalAge(int animalId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "UPDATE Animals SET Age = Age + 1 WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", animalId);
                cmd.ExecuteNonQuery();
            }
        }
        public static void KillAnimal(int animalId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Animals SET IsAlive = 0 WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", animalId);
                cmd.ExecuteNonQuery();
            }

        }
        public static int GetMilkCount(int animalId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT ISNULL(MilkProductionCount, 0) FROM Animals WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", animalId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static void IncrementMilkCount(int animalId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE Animals SET MilkProductionCount = ISNULL(MilkProductionCount, 0) + 1 WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", animalId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int GetAliveCowId()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT TOP 1 Id FROM Animals WHERE SpeciesId = 3 AND IsAlive = 1";
                // Burada SpeciesId = 3 diyelim, inek türü için (veritabanındaki id'yi kontrol et)
                using (var cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }
        public static bool HasAnyAliveCow()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Animals WHERE SpeciesId = 3 AND IsAlive = 1"; // 3: İnek türü ID'si
                using (var cmd = new SqlCommand(query, conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }



    }
}