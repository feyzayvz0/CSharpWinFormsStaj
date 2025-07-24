using StajOdeviIlk.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static void AddAnimal(Animal animal)
        {
            if (animal.SpeciesId == 1 && HasAnyAliveChicken()) return; // Tavuksa ve zaten canlı varsa ekleme

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

        public static int GetAliveChickenId()
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT TOP 1 Id FROM Animals WHERE SpeciesId = 1 AND IsAlive = 1";
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
                string query = "SELECT COUNT(*) FROM Animals WHERE SpeciesId = 1 AND IsAlive = 1";
                using (var cmd = new SqlCommand(query, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }


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

                    return cmd.ExecuteNonQuery();
                }
            }
        }

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
                string query = "SELECT COUNT(*) FROM Animals WHERE SpeciesId = 1 AND IsAlive = 1";
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
                string query = "SELECT TOP 1 Id FROM Animals WHERE SpeciesId = 2 AND IsAlive = 1";
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
                string query = "SELECT COUNT(*) FROM Animals WHERE SpeciesId = 2 AND IsAlive = 1";
                using (var cmd = new SqlCommand(query, conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public static bool HasAnyAliveSheep()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Animals WHERE SpeciesId = 3 AND IsAlive = 1"; // Koyun ID'si 3
                SqlCommand command = new SqlCommand(query, connection);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        public static int? GetAliveSheepId()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 Id FROM Animals WHERE SpeciesId = 4 AND IsAlive = 1"; // Koyun ID'si 3'ten 4'e değişti
                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result);
                return null;
            }
        }
        public static void IncrementWoolCount(int sheepId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "UPDATE Animals SET WoolProductionCount = ISNULL(WoolProductionCount, 0) + 1 WHERE Id = @Id AND SpeciesId = 3"; // Koyun ID'si 3
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", sheepId);
                command.ExecuteNonQuery();
            }
        }


        public static int GetWoolCount(int sheepId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT ISNULL(WoolProductionCount, 0) FROM Animals WHERE Id = @Id AND SpeciesId = 3"; // Koyun ID'si 3
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", sheepId);
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public static string GetAnimalGender(int animalId)
        {
            string gender = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT Gender FROM Animals WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", animalId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    gender = reader["Gender"].ToString();
                }

                reader.Close();
            }

            return gender;
        }
        public static bool HasAnyAliveGoose()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Animals WHERE SpeciesId = 4 AND IsAlive = 1"; // Kaz ID'si 4
                SqlCommand command = new SqlCommand(query, connection);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        public static int? GetAliveGooseId()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 Id FROM Animals WHERE SpeciesId = 4 AND IsAlive = 1"; // Kaz ID'si 4
                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result);
                return null;
            }
        }
        public static void IncrementGooseProductCount(int gooseId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string selectQuery = "SELECT FeatherProductionCount FROM Animals WHERE Id = @id AND SpeciesId = 4"; // Kaz ID'si 4
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@id", gooseId);

                int currentCount = Convert.ToInt32(selectCommand.ExecuteScalar());

                string updateFeatherQuery = "UPDATE Animals SET FeatherProductionCount = FeatherProductionCount + 1 WHERE Id = @id AND SpeciesId = 4"; // Kaz ID'si 4
                SqlCommand updateCommand = new SqlCommand(updateFeatherQuery, connection);
                updateCommand.Parameters.AddWithValue("@id", gooseId);
                updateCommand.ExecuteNonQuery();

                int newCount = currentCount + 1;
                if (newCount % 3 == 0)
                {
                    string ageUpdateQuery = "UPDATE Animals SET Age = Age + 1 WHERE Id = @id AND SpeciesId = 4"; // Kaz ID'si 4
                    SqlCommand ageCommand = new SqlCommand(ageUpdateQuery, connection);
                    ageCommand.Parameters.AddWithValue("@id", gooseId);
                    ageCommand.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateAnimalGender(int animalId, string gender)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Animals SET Gender = @Gender WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Id", animalId);
                cmd.ExecuteNonQuery();
            }
        }

        // 📊 İstatistikleri Getir (Güncellenmiş)
        public static DataTable GetStatistics()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT
                        ASp.Name AS [Animal Type],
                        COUNT(CASE WHEN A.IsAlive = 1 THEN A.Id ELSE NULL END) AS [Alive Animals], -- Geri geldi
                        COUNT(CASE WHEN A.IsAlive = 0 THEN A.Id ELSE NULL END) AS [Dead Animals],  -- Geri geldi
                        ISNULL(SUM(CASE WHEN ASp.Name = 'Tavuk' THEN A.EggProductionCount ELSE 0 END), 0) AS [Total Eggs Produced],
                        ISNULL(SUM(CASE WHEN ASp.Name = 'İnek' THEN A.MilkProductionCount ELSE 0 END), 0) AS [Total Milk Produced],
                        ISNULL(SUM(CASE WHEN ASp.Name = 'Koyun' THEN A.WoolProductionCount ELSE 0 END), 0) AS [Total Wool Produced],
                        ISNULL(SUM(CASE WHEN ASp.Name = 'Kaz' THEN A.FeatherProductionCount ELSE 0 END), 0) AS [Total Feathers Produced],
                        ISNULL(SUM(CASE WHEN PT.Name = 'Egg' AND P.IsSold = 0 THEN P.Quantity ELSE 0 END), 0) AS [Eggs In Stock],
                        ISNULL(SUM(CASE WHEN PT.Name = 'Egg' AND P.IsSold = 1 THEN P.Quantity ELSE 0 END), 0) AS [Eggs Sold],
                        ISNULL(SUM(CASE WHEN PT.Name = 'Milk' AND P.IsSold = 0 THEN P.Quantity ELSE 0 END), 0) AS [Milk In Stock],
                        ISNULL(SUM(CASE WHEN PT.Name = 'Milk' AND P.IsSold = 1 THEN P.Quantity ELSE 0 END), 0) AS [Milk Sold],
                        ISNULL(SUM(CASE WHEN PT.Name = 'Wool' AND P.IsSold = 0 THEN P.Quantity ELSE 0 END), 0) AS [Wool In Stock],
                        ISNULL(SUM(CASE WHEN PT.Name = 'Wool' AND P.IsSold = 1 THEN P.Quantity ELSE 0 END), 0) AS [Wool Sold],
                        ISNULL(SUM(CASE WHEN PT.Name = 'Feather' AND P.IsSold = 0 THEN P.Quantity ELSE 0 END), 0) AS [Feathers In Stock],
                        ISNULL(SUM(CASE WHEN PT.Name = 'Feather' AND P.IsSold = 1 THEN P.Quantity ELSE 0 END), 0) AS [Feathers Sold],
                        (SELECT ISNULL(SUM(Amount), 0) FROM CashRegister WHERE Amount > 0) AS [Total Earned Cash]
                    FROM
                        AnimalSpecies ASp
                    LEFT JOIN
                        Animals A ON ASp.Id = A.SpeciesId
                    LEFT JOIN
                        Products P ON A.Id = P.AnimalId
                    LEFT JOIN
                        ProductTypes PT ON P.ProductTypeId = PT.Id
                    GROUP BY
                        ASp.Name
                    ORDER BY
                        ASp.Name;
                ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

    }
}