using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Refresh
{
    internal class EF
    {
        public class NorthwindDbContext : DbContext
        {
            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Customers> Customers { get; set; }
            public DbSet<Orders> Orders { get; set; }
            public DbSet<OrderDetails> OrderDetail { get; set; }

            public NorthwindDbContext() : base() { }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"server=(local);database=northwind;integrated security=sspi;trustservercertificate=true");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Category>()  //The Category Entity 
                    .HasMany(c => c.Products) //Has Many relationship with Products 
                    .WithOne(p => p.Category) //with one 
                    .HasForeignKey(p => p.CategoryId)
                    .IsRequired();

                // Configure the one-to-one relationship between Customers and Orders
                modelBuilder.Entity<Customers>()
                    .HasOne(c => c.Order)
                    .WithOne(o => o.Customer)
                    .HasForeignKey<Orders>(o => o.CustomerId);

                modelBuilder.Entity<Orders>()
                    .HasMany(o => o.OrderDetails)
                    .WithOne(od => od.Order)
                    .HasForeignKey(od => od.OrderId);

                modelBuilder.Entity<OrderDetails>()
                    .HasOne(od => od.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(od => od.OrderId);
            }
        }
    }
}
