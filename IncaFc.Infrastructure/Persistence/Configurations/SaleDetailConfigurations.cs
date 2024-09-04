using IncaFc.Domain.ProductAggregate;
using IncaFc.Domain.ProductAggregate.ValueObjects;
using IncaFc.Domain.SaleAggregate.Entities;
using IncaFc.Domain.SaleAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SaleDetailConfigurations : IEntityTypeConfiguration<SaleDetail>
{
    public void Configure(EntityTypeBuilder<SaleDetail> builder)
    {
        builder.ToTable("SaleDetails");

        builder.HasKey(sd => sd.Id);

        builder
            .Property(sd => sd.Id)
            .HasColumnName("SaleDetailId")
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => SaleDetailId.Create(value));

        builder.Property(sd => sd.Quantity).IsRequired();

        builder
            .Property(m => m.ProductId)
            .HasConversion(
                id => id.Value, // Convierte de CustomerId a Guid
                value => ProductId.Create(value) // Convierte de Guid a CustomerId
            )
            .HasColumnName("ProductId"); // Asigna el nombre de la columna

        builder
            .Property(sd => sd.ProductId)
            .HasConversion(id => id.Value, value => ProductId.Create(value))
            .IsRequired();
    }
}
