using IncaFc.Domain.CustomerAggregate;
using IncaFc.Domain.CustomerAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncaFc.Infrastructure.Persistence.Configurations;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        ConfigureCustomerTable(builder);
    }

    private void ConfigureCustomerTable(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .HasConversion(
                id => id.Value,
                value => CustomerId.Create(value));

        builder.Property(m => m.Name)
            .HasMaxLength(100);
    }
}