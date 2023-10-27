using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<TransactionDetail> TransactionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Customer Table
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1,
                Nama = "Customer1",
                Alamat = "Bandung"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 2,
                Nama = "Customer2",
                Alamat = "Jakarta"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 3,
                Nama = "Customer3",
                Alamat = "Semarang"
            });

            // Seed Food Table
            modelBuilder.Entity<Food>().HasData(new Food
            {
                Id = 1,
                Nama = "Sate",
                Harga = 12000
            });
            modelBuilder.Entity<Food>().HasData(new Food
            {
                Id = 2,
                Nama = "Gado-gado",
                Harga = 10000
            });
            modelBuilder.Entity<Food>().HasData(new Food
            {
                Id = 3,
                Nama = "Bubur",
                Harga = 8000
            });
        }
    }
}
