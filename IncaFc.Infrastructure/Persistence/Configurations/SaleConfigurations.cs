using IncaFc.Domain.CustomerAggregate.ValueObjects;
using IncaFc.Domain.ProductAggregate.ValueObjects;
using IncaFc.Domain.SaleAggregate;
using IncaFc.Domain.SaleAggregate.ValueObjects;
using IncaFc.Domain.UserAggregate;
using IncaFc.Domain.UserAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncaFc.Infrastructure.Persistence.Configurations;

public class SaleConfigurations : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        ConfigureSaleTable(builder);
        ConfigureSaleDetailIdTable(builder);
    }

    private void ConfigureSaleTable(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => SaleId.Create(value));

        builder.Property(m => m.Name)
            .HasMaxLength(100);

        builder.Property(m => m.State)
            .IsRequired();

        builder.Property(m => m.Reason)
            .HasMaxLength(250);

        builder.Property(m => m.CustomerId)
            .HasColumnName("SaleDetailId")
            .HasConversion(
                id => id.Value,
                value => CustomerId.Create(value));

        builder.Property(m => m.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
    }

    private void ConfigureSaleDetailIdTable(EntityTypeBuilder<Sale> builder)
    {
        builder.OwnsOne(m => m.SaleDetail, sd =>
        {
            sd.ToTable("SalesDetails");

            sd.WithOwner().HasForeignKey("SaleId");

            sd.HasKey(d => d.Id);

            sd.Property(d => d.Id)
               .HasColumnName("SaleDetailId")
               .ValueGeneratedNever()
               .HasConversion(
                    id => id.Value,
                    value => SaleDetailId.Create(value));

            sd.Property(d => d.Igv)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

            sd.Property(d => d.TotalBruto)
               .HasColumnType("decimal(18,2)");

            sd.Property(d => d.TotalNeto)
                .HasColumnType("decimal(18,2)");

            sd.OwnsMany(d => d.ProductIds, br =>
            {
                br.ToTable("SalesDetailsProductIds");

                sd.HasKey(d => d.Id);

                br.WithOwner().HasForeignKey("SaleDetailId");

                br.Property(i => i.Value)
                    .HasColumnName("SaleDetailProducId");
            });
        });

        builder.Metadata.FindNavigation(nameof(Sale.SaleDetail))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

}