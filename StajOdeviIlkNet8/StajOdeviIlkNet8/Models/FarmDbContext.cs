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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AnimalSpecies>().HasData(
                new AnimalSpecies { Id = 1, Name = "Chicken" },
                new AnimalSpecies { Id = 2, Name = "Cow" },
                new AnimalSpecies { Id = 3, Name = "Sheep" },
                new AnimalSpecies { Id = 4, Name = "Goose" }
            );

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "Egg" },
                new ProductType { Id = 2, Name = "Milk" },
                new ProductType { Id = 3, Name = "Wool" },
                new ProductType { Id = 4, Name = "Feather" }
            );

            modelBuilder.Entity<CashRegister>().HasData(
                new CashRegister { Id = 1, Amount = 500, Date = new DateTime(2025, 8, 7) }
            );
        }

    }
}

