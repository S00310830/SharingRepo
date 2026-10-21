using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week32026.S00310830.BusinessModel;

namespace Week3ConsoleApp2026.S00310830
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }
        public DbSet<SupplierProduct>? SupplierProducts { get; set; }

        public ProductDbContext() { }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Week3ConnectionString"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name}, LogLevel.Information)
                .EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(c => c.CategoryID);
                e.Property(k => k.CategoryID)
                .UseIdentityColumn(1, 1);
            });

            modelBuilder.Entity<Product>()
                .HasKey(e => e.ProductID);

            modelBuilder.Entity<Supplier>()
                .HasKey(e => e.SupplierID);

            modelBuilder.Entity<SupplierProduct>()
                .HasKey(e => new { e.SupplierID, e.ProductID });

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOne(e => e.associatedCategory);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Suppliers)
                .UsingEntity<SupplierProduct>();
        }
    }
}
