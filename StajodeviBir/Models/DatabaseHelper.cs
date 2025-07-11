using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace StajodeviBir.Helpers
{
    public static class DatabaseHelper
    {
        // Kendi SQL bağlantı cümleni yaz
        public static string ConnectionString = @"Data Source=.;Initial Catalog=StajodeviBirDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
