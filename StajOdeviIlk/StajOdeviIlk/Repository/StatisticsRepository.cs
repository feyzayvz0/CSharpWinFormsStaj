using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlk.Repository
{
    public class StatisticsRepository
    {
        private readonly string _connectionString;

        public StatisticsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetStatistics()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"
SELECT
    ASp.Name AS [Animal Type],
    COUNT(CASE WHEN A.IsAlive = 0 THEN 1 ELSE NULL END) AS [Dead Animals],

    -- Yumurta: Sadece Chicken için
    CASE WHEN ASp.Name = 'Chicken'
        THEN ISNULL(SUM(CASE WHEN PT.Name = 'Egg' AND P.IsSold = 0 THEN P.Quantity ELSE 0 END), 0)
        ELSE 0
    END AS [Eggs In Stock],

    CASE WHEN ASp.Name = 'Chicken'
        THEN ISNULL(SUM(CASE WHEN PT.Name = 'Egg' AND P.IsSold = 1 THEN P.Quantity ELSE 0 END), 0)
        ELSE 0
    END AS [Eggs Sold],

    -- Süt: Sadece Cow için
    CASE WHEN ASp.Name = 'Cow'
        THEN ISNULL(SUM(CASE WHEN PT.Name = 'Milk' AND P.IsSold = 0 THEN P.Quantity ELSE 0 END), 0)
        ELSE 0
    END AS [Milk In Stock],

    CASE WHEN ASp.Name = 'Cow'
        THEN ISNULL(SUM(CASE WHEN PT.Name = 'Milk' AND P.IsSold = 1 THEN P.Quantity ELSE 0 END), 0)
        ELSE 0
    END AS [Milk Sold],

    -- Yün: Sadece Sheep için
    CASE WHEN ASp.Name = 'Sheep'
        THEN ISNULL(SUM(CASE WHEN PT.Name = 'Wool' AND P.IsSold = 0 THEN P.Quantity ELSE 0 END), 0)
        ELSE 0
    END AS [Wool In Stock],

    CASE WHEN ASp.Name = 'Sheep'
        THEN ISNULL(SUM(CASE WHEN PT.Name = 'Wool' AND P.IsSold = 1 THEN P.Quantity ELSE 0 END), 0)
        ELSE 0
    END AS [Wool Sold],

    -- Tüy: Sadece Goose için
    CASE WHEN ASp.Name = 'Goose'
        THEN ISNULL(SUM(CASE WHEN PT.Name = 'Feather' AND P.IsSold = 0 THEN P.Quantity ELSE 0 END), 0)
        ELSE 0
    END AS [Feathers In Stock],

    CASE WHEN ASp.Name = 'Goose'
        THEN ISNULL(SUM(CASE WHEN PT.Name = 'Feather' AND P.IsSold = 1 THEN P.Quantity ELSE 0 END), 0)
        ELSE 0
    END AS [Feathers Sold],

    (SELECT ISNULL(SUM(Amount), 0) FROM CashRegister WHERE Amount > 0) AS [Total Earned Cash]

FROM AnimalSpecies ASp
LEFT JOIN Animals A ON ASp.Id = A.SpeciesId
LEFT JOIN Products P ON A.Id = P.AnimalId
LEFT JOIN ProductTypes PT ON P.ProductTypeId = PT.Id

GROUP BY ASp.Name
ORDER BY ASp.Name;
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