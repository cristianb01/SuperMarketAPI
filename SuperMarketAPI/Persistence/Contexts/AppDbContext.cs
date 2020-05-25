using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperMarketAPI.Models;

namespace SuperMarketAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet <ProductPurchase> ProductPurchases { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            optionsBuilder.UseMySql(configuration.GetConnectionString("SuperMarket"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);


            builder.Entity<Purchase>().ToTable("purchases");
            builder.Entity<Purchase>().HasKey(p => p.Id);
            builder.Entity<Purchase>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Purchase>().Property(p => p.ClientName).IsRequired().HasMaxLength(30);
            builder.Entity<Purchase>().Property(p => p.Date).IsRequired();
            builder.Entity<Purchase>().Property(p => p.Price).IsRequired();
            builder.Entity<Purchase>().HasMany(p => p.Products);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
                new Category { Id = 101, Name = "Dairy" }
            );

            builder.Entity<Product>().ToTable("products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();


            builder.Entity<ProductPurchase>().ToTable("productpurchase");
            builder.Entity<ProductPurchase>().HasKey(p => new { p.ProductId, p.PurchaseId });
            builder.Entity<ProductPurchase>().Property(p => p.Quantity).IsRequired();

        }
    }
}
