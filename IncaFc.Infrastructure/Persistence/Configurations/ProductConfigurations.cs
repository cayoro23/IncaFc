using IncaFc.Domain.ProductAggregate;
using IncaFc.Domain.ProductAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncaFc.Infrastructure.Persistence.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        ConfigureProductTable(builder);
        ConfigureCategoryIdsTable(builder);
        ConfigureBrandIdsTable(builder);
    }

    private void ConfigureCategoryIdsTable(EntityTypeBuilder<Product> builder)
    {
        builder.OwnsMany(m => m.CategoryIds, ct =>
        {
            ct.ToTable("ProductCategoryIds");

            ct.WithOwner().HasForeignKey("ProductId");

            ct.HasKey("Id");

            ct.Property(d => d.Value)
                .HasColumnName("CategoryId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Product.CategoryIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);

    }

    private void ConfigureBrandIdsTable(EntityTypeBuilder<Product> builder)
    {
        builder.OwnsMany(m => m.BrandIds, br =>
        {
            br.ToTable("ProductBrandIds");

            br.WithOwner().HasForeignKey("ProductId");

            br.HasKey("Id");

            br.Property(d => d.Value)
                .HasColumnName("BrandId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Product.BrandIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureProductTable(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .HasConversion(
                id => id.Value,
                value => ProductId.Create(value));

        builder.Property(m => m.Name)
            .HasMaxLength(100);

        builder.Property(m => m.Description)
            .HasMaxLength(100);

        builder.OwnsOne(m => m.Price, price =>
        {
            price.Property(p => p.Amount)
                .HasColumnName("Price_Amount")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            price.Property(p => p.Currency)
                .HasColumnName("Price_Currency")
                .HasMaxLength(3)
                .IsRequired();

            price.Property(p => p.UnitOfMeasure)
                .HasColumnName("Price_UnitOfMeasure")
                .HasMaxLength(10)
                .IsRequired();
        });

        builder.OwnsOne(m => m.Location, location =>
        {
            location.Property(l => l.Name)
                .HasColumnName("Location_Name")
                .HasMaxLength(50)
                .IsRequired();

            location.Property(l => l.Address)
                .HasColumnName("Location_Address")
                .HasMaxLength(100)
                .IsRequired();

            location.Property(l => l.Latitude)
                .HasColumnName("Location_Latitude")
                .IsRequired();

            location.Property(l => l.Longitude)
                .HasColumnName("Location_Longitude")
                .IsRequired();
        });
    }
}