using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.Infra.Mapping
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("branch");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Branch)
                .HasForeignKey(o => o.IdBranch);
        }
    }
}
