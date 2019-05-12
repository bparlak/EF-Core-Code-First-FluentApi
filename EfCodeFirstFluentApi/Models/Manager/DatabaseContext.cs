using EfCodeFirstFluentApi.Models.EfCodeFirstMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCodeFirstFluentApi.Models.Manager
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer() { CustomerId = "a1", FirstName = "Burak", SecondName = "Parlak", Email = "info@burakparlak.com", City = "Ankara", Country = "Turkey", Age = 29, UserName = "bparlak" },
                new Customer() { CustomerId = "a2", FirstName = "Burak", SecondName = "Parlak", Email = "info@burakparlak.com", City = "Ankara", Country = "Turkey", Age = 29, UserName = "bparlak" },
                new Customer() { CustomerId = "a3", FirstName = "Burak", SecondName = "Parlak", Email = "info@burakparlak.com", City = "Ankara", Country = "Turkey", Age = 29, UserName = "bparlak" },
                new Customer() { CustomerId = "a4", FirstName = "Burak", SecondName = "Parlak", Email = "info@burakparlak.com", City = "Ankara", Country = "Turkey", Age = 29, UserName = "bparlak" }
                );
            modelBuilder.Entity<Order>().HasData(new Order() { OrderId = 1, CustomerId = "a1", OrderDate = DateTime.Now });
        }
    }
}
