using EfCodeFirstFluentApi.Models.EfCodeFirstMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCodeFirstFluentApi.Models.Manager
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
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
                new Customer() { CustomerId = "a1",  CompanyName = "A", ContactName = "burak parlak", City = "Ankara", Country = "Turkey" }, 
                new Customer() { CustomerId = "a2", CompanyName = "B", ContactName = "burak parlak", City = "Ankara", Country = "Turkey" },
                new Customer() { CustomerId = "a3", CompanyName = "C", ContactName = "burak parlak", City = "Ankara", Country = "Turkey" },
                new Customer() { CustomerId = "a4", CompanyName = "D", ContactName = "burak parlak", City = "Ankara", Country = "Turkey" }
                );
            modelBuilder.Entity<Order>().HasData(new Order() { OrderId=1,CustomerId="a1",OrderDate=DateTime.Now });
        }
    }
}
