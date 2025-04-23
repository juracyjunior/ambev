using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.Infra.Mapping
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()");
            
            builder.Property(p => p.IdCustomer)
                .HasColumnName("idcustomer")
                .IsRequired();
            
            builder.Property(p => p.IdBranch)
                .HasColumnName("idbranch")
                .IsRequired();
            
            builder.Property(p => p.SaleDate)
                .HasColumnName("saledate")
                .IsRequired();

            builder.Property(p => p.SaleNumber)
                .HasColumnName("salenumber")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(p => p.IsCancelled)
                .IsRequired()
                .HasColumnName("iscancelled")
                .HasDefaultValue(false);

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.IdCustomer);
            
            builder.HasOne(o => o.Branch)
                .WithMany(b => b.Orders)
                .HasForeignKey(o => o.IdBranch);

            builder.HasMany(o => o.Items)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.IdOrder);
        }
    }
}
