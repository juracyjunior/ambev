using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.Infra.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.Items)
                .WithOne(o => o.Product)
                .HasForeignKey(o => o.IdProduct);
        }
    }
}
