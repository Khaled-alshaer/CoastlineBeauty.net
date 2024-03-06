using CoastlineBeauty.Models;
using Microsoft.EntityFrameworkCore;

namespace CoastlineBeauty.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
            
        }

        // Create Database Table
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Brand = "Dior", Name = "Savage", Size = 100, Type = "EDP", Gender = "Male", Price = 100.00, Quantity = 100},
                new Product { ProductId = 2, Brand = "Polo", Name = "Polo Red", Size = 125, Type = "EDT", Gender = "Male", Price = 70.00, Quantity = 100}
                );
        }
    }
}
