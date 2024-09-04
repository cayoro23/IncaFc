using IncaFc.Domain.CustomerAggregate;
using IncaFc.Domain.ProductAggregate;
using IncaFc.Domain.SaleAggregate;
using IncaFc.Domain.SaleAggregate.Entities;
using IncaFc.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace IncaFc.Infrastructure.Persistence;

public class IncaFcDbContext(DbContextOptions<IncaFcDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Sale> Sales { get; set; } = null!;
    public DbSet<SaleDetail> SaleDetails { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IncaFcDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
