using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCodeFirstFluentApi.Models.EfCodeFirstMappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer> 
    {

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(t => t.CustomerId);
            builder.Property(t => t.CustomerId)
                .IsRequired();
            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(20);/*.IsUnicode(false); varchar tanımlanıyor nvarcharın 2 katı tutuyor*/
            builder.Property(t => t.SecondName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(t => t.City).HasMaxLength(15);
            builder.Property(t => t.Email).IsRequired();
            builder.Property(t => t.Country).HasMaxLength(15);

            builder.ToTable("Customers");
            builder.Property(t => t.CustomerId).HasColumnName("CustomerId");
            builder.Property(t => t.UserName).HasColumnName("UserName");
            builder.Property(t => t.City).HasColumnName("City");
            builder.Property(t => t.FirstName).HasColumnName("FirstName");
            builder.Property(t => t.SecondName).HasColumnName("SecondName");
            builder.Property(t => t.Country).HasColumnName("Country");
            builder.Property(t => t.Age).HasColumnName("Age");
        }
    }
}
