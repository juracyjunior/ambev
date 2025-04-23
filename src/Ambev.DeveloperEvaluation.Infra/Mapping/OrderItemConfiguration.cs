using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.Infra.Mapping
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("orderItem");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(p => p.IdOrder)
                .HasColumnName("idOrder")
                .IsRequired();
            
            builder.Property(p => p.IdProduct)
                .HasColumnName("idProduct")
                .IsRequired();
            
            builder.Property(p => p.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(p => p.UnitPrice)
                .HasColumnName("unitPrice")
                .IsRequired();

            builder.Property(p => p.Discount)
                .HasColumnName("discount");

            builder.HasOne(o => o.Order)
                .WithMany(c => c.Items)
                .HasForeignKey(o => o.IdOrder);
            
            builder.HasOne(o => o.Product)
                .WithMany(b => b.Items)
                .HasForeignKey(o => o.IdProduct);
        }
    }
}
