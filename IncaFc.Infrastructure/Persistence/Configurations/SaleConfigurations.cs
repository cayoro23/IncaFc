using IncaFc.Domain.CustomerAggregate;
using IncaFc.Domain.CustomerAggregate.ValueObjects;
using IncaFc.Domain.SaleAggregate;
using IncaFc.Domain.SaleAggregate.ValueObjects;
using IncaFc.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SaleConfigurations : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        ConfigureSaleTable(builder);
        ConfigureSaleDetailRelationship(builder);
    }

    private void ConfigureSaleTable(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(m => m.Id);

        builder
            .Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => SaleId.Create(value));

        builder.Property(m => m.Name).HasMaxLength(100);

        builder.Property(m => m.State).IsRequired();

        builder.Property(m => m.Reason).HasMaxLength(250);

        builder.Property(m => m.Total).HasColumnType("decimal(18,2)");

        builder
            .Property(m => m.CustomerId)
            .HasConversion(id => id.Value, value => CustomerId.Create(value))
            .HasColumnName("CustomerId");

        builder
            .Property(m => m.UserId)
            .HasColumnName("UserId")
            .HasConversion(id => id.Value, value => UserId.Create(value));

        builder
            .HasMany(m => m.SaleDetails)
            .WithOne()
            .HasForeignKey("SaleId")
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureSaleDetailRelationship(EntityTypeBuilder<Sale> builder)
    {
        builder
            .HasMany(s => s.SaleDetails)
            .WithOne()
            .HasForeignKey("SaleId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
