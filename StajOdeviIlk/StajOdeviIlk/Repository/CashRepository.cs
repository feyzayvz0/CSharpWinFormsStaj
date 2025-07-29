using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StajOdeviIlk.Repository;


namespace StajOdeviIlk.Repositories
{
    public class CashRepository : ICashRepository
    {
        private readonly string _connectionString;

        public CashRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCash(decimal amount)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE CashRegister SET Balance = Balance + @Amount", connection);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.ExecuteNonQuery();
            }
        }
        public void DecreaseCash(decimal amount)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO CashRegister (Amount, Date) VALUES (@Amount, @Date)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Amount", -amount); // Para çıkışı
                command.Parameters.AddWithValue("@Date", DateTime.Now);
                command.ExecuteNonQuery();
            }
        }

        public decimal GetTotalCash()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT ISNULL(SUM(Amount), 0) FROM CashRegister";
                SqlCommand command = new SqlCommand(query, connection);

                return (decimal)command.ExecuteScalar();
            }
        }

        public bool HasEnoughCash(decimal amount)
        {
            return GetTotalCash() >= amount;
        }

    }
}