/* Group:      Nightingale
   References: Liu, F (2021) Full C# Project: Supermarket Management System | ASP.NET Core Blazor, EF Core, SQL Server, Identity source code (Version 16) [Source code]. https://www.youtube.com/watch?v=DWrH7br4DsM&t=140s

 */

using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Linq;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext 
    {
        public MarketContext(DbContextOptions options) : base(options) 
        {            
        }
        // Getters and Setters
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // seeding some data
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, Name = "", Description = "" },
                    new Category { CategoryId = 2, Name = "", Description = "" },
                    new Category { CategoryId = 3, Name = "", Description = "" }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId = 1, CategoryId = 1, Name = "", Quantity = 100, Price = 12000 },
                    new Product { ProductId = 2, CategoryId = 1, Name = "", Quantity = 150, Price = 3000 },
                    new Product { ProductId = 3, CategoryId = 2, Name = "", Quantity = 300, Price = 99.99 },
                    new Product { ProductId = 4, CategoryId = 2, Name = "", Quantity = 170, Price = 79.99 }
                );
            
            modelBuilder.Entity<Vehicle>().HasData(
                    new Vehicle { VehicleId = 1, Type = "JAC 2019", NumberPlate = "CAA 183761" },
                    new Vehicle { VehicleId = 2, Type = "KIA", NumberPlate = "CAA 89312" },
                    new Vehicle { VehicleId = 3, Type = "NISSAN / 7 Seater ", NumberPlate = "CAA 268430" }
                );

            modelBuilder.Entity<Stock>().HasData(
                    new Stock { StockId = 1, Name = "Furniture", Type = "Collection" },
                    new Stock { StockId = 2, Name = "Bric n brac", Type = "Collection" },
                    new Stock { StockId = 3, Name = "Clothing", Type = "Delivery" }
                );
        }
    }
}
