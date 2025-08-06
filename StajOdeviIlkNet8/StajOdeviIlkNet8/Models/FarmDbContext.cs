using Microsoft.EntityFrameworkCore;
using StajOdeviIlkNet8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajOdeviIlkNet8.Models
{
    public class FarmDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalSpecies> AnimalSpecies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<Chicken> Chickens { get; set; }
        public DbSet<Cow> Cows { get; set; }
        public DbSet<Sheep> Sheeps { get; set; }
        public DbSet<Goose> Geese { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=FEYZA;Database=StajOdeviIlkNet8Db;Trusted_Connection=True;TrustServerCertificate=True;");
        }

    }
}
