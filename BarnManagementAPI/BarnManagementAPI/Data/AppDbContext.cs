using BarnManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BarnManagementAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Farm> Farms => Set<Farm>();
        public DbSet<Animal> Animals => Set<Animal>();
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product → Animal CASCADE DELETE
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Animal)
                .WithMany(a => a.Products)
                .HasForeignKey(p => p.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            // DECIMAL precision (uyarıları keser)
            modelBuilder.Entity<Product>()
                .Property(p => p.SalePrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<User>()
                .Property(u => u.Balance)
                .HasPrecision(18, 2);
        }


    }
}
