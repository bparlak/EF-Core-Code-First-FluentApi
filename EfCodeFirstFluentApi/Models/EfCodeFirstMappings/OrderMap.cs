using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCodeFirstFluentApi.Models.EfCodeFirstMappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        //public OrderMap(EntityTypeBuilder<Order> builder)
        //{
        //    builder.HasKey(t => t.OrderId);
        //    builder.Property(t => t.CustomerId).IsFixedLength()//varcharyerine char olacak
        //        .HasMaxLength(5);

        //    builder.ToTable("Orders");

        //    builder.Property(t => t.OrderId).HasColumnName("OrderId");
        //    builder.Property(t => t.CustomerId).HasColumnName("CustomerId");
        //    builder.Property(t => t.OrderDate).HasColumnName("OrderDate");

        //    //1-n ilişki hasoptional ile üretiliyor
        //    builder.HasOne(t => t.Customer)
        //        .WithMany(t => t.Orders)
        //        .HasForeignKey(f => f.CustomerId);

        //    /*new AccountMap(modelBuilder.Entity<Account>()); //databasecontexte*/
        //}
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(t => t.OrderId);
            builder.Property(t => t.CustomerId)
                .IsRequired();
            //builder.Property(t => t.CustomerId).IsFixedLength()//varcharyerine char olacak

            builder.ToTable("Orders");

            builder.Property(t => t.OrderId).HasColumnName("OrderId");
            builder.Property(t => t.CustomerId).HasColumnName("CustomerId");
            builder.Property(t => t.OrderDate).HasColumnName("OrderDate");

            //1-n ilişki hasoptional ile üretiliyor
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.Orders)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
