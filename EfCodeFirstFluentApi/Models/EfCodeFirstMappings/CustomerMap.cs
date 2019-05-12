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
                .IsRequired()
                .HasMaxLength(5);
            builder.Property(t => t.CompanyName)
                .IsRequired()
                .HasMaxLength(40);/*.IsUnicode(false); varchar tanımlanıyor nvarcharın 2 katı tutuyor*/
            builder.Property(t => t.City).HasMaxLength(15);
            builder.Property(t => t.ContactName).HasMaxLength(30);
            builder.Property(t => t.Country).HasMaxLength(15);

            builder.ToTable("Customers");
            builder.Property(t => t.CustomerId).HasColumnName("CustomerId");
            builder.Property(t => t.CompanyName).HasColumnName("CompanyName");
            builder.Property(t => t.City).HasColumnName("City");
            builder.Property(t => t.ContactName).HasColumnName("ContactName");
            builder.Property(t => t.Country).HasColumnName("Country");
        }
    }
}
