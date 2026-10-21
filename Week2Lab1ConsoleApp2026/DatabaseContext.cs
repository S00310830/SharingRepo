using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Week2Lab1ConsoleApp2026
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var myConnectionString = ConfigurationManager.ConnectionStrings["RAD301Week2Lab2026Connection"].ConnectionString;

            optionsBuilder
                .UseSqlServer(myConnectionString)
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging(true);            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                {
                    new Category{ CategoryID = 1, Description = "Hardware" },
                    new Category{ CategoryID = 2, Description = "Electrical Appliances" }
                    }
            );
            modelBuilder.Entity<Product>()
                .HasData(new Product[]
                {
                    new Product{ ProductId = 1, CategoryId = 1, Description = "9 inch nails", UnitPrice = 0.10f, DateFirstIssued = new DateTime(2019, 12, 13), QuantityInStock = 200 },
                    new Product{ ProductId = 2, CategoryId = 1, Description = "9 inch bolts", UnitPrice = 0.20f, DateFirstIssued = new DateTime(2019, 12, 17), QuantityInStock = 120 },
                    new Product{ ProductId = 3, CategoryId = 2, Description = "Chimney Hoover", UnitPrice = 100.50f, DateFirstIssued = new DateTime(2019, 12, 21), QuantityInStock = 10 },
                    new Product{ ProductId = 4, CategoryId = 2, Description = "Washing Machine", UnitPrice = 399.99f, DateFirstIssued = new DateTime(2019, 12, 20), QuantityInStock = 7 }
                }
            );
            modelBuilder.Entity<Supplier>()
                .HasData(new Supplier[]
                {
                    new Supplier{ SupplierID = 1, SupplierName = "Joe bloggs", SupplierAddressLine1 = "The Coop", SupplierAddressLine2 = "Copersville" },
                    new Supplier { SupplierID = 2, SupplierName = "Mary Quant", SupplierAddressLine1 = "Priory Road", SupplierAddressLine2 = "Paris" }
                }
            );
            modelBuilder.Entity<SupplierProduct>()
                .HasData(new SupplierProduct[]
                {
                    new SupplierProduct{ SupplierID = 1, ProductID = 1, DateFirstSupplied = new DateTime(2019, 12, 7) },
                    new SupplierProduct { SupplierID = 1, ProductID = 2, DateFirstSupplied = new DateTime(2019, 12, 15) },
                    new SupplierProduct { SupplierID = 2, ProductID = 3, DateFirstSupplied = new DateTime(2019, 12, 10) },
                    new SupplierProduct { SupplierID = 2, ProductID = 4, DateFirstSupplied = new DateTime(2019, 12, 9) }
                }
            );
        }
    }
}
