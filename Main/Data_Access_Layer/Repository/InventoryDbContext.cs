using System;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApi.Repository.Entities;

#nullable disable

namespace WebApi.Repository
{
    public partial class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
        {
        }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=BS-161\\SQLEXPRESS;Initial Catalog=Inventory;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_dbo.Products_dbo.Categories_Category_ID");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.Stocks_dbo.Products_Product_ID");
            });


            
            modelBuilder.Entity<Customer>()
               .Property(a => a.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>()
                .Property(a => a.Address).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Customer>()
                .Property(a => a.Contact).IsRequired().HasMaxLength(20);


            modelBuilder.Entity<Category>()
                .Property(c => c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(a => a.Category).HasForeignKey(a => a.CategoryId);



            //restrict
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(a => a.Customer).HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasMany(b => b.Sales)
                .WithOne(a => a.Product).HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasMany(a => a.Stocks)
                .WithOne(c => c.Product).HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(a => a.Category).HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);




            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
