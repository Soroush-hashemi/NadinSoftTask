using Domain.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Command;
internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.ProduceDate).IsUnique();
        builder.HasIndex(x => x.ManufacturerEmail).IsUnique();
        builder.Property(x => x.ManufacturerEmail)
            .IsRequired()
            .HasMaxLength(80);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(80);
        builder.Property(x => x.IsAvailable)
            .HasDefaultValue(true);

        builder.OwnsOne(c => c.ManufacturerPhone, config =>
        {
            config.Property(b => b.Value)
                .HasColumnName("ManufacturerPhone")
                .IsRequired().HasMaxLength(11);
        });
    }
}