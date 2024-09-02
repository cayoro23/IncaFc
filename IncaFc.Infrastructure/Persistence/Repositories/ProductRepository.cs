using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.ProductAggregate;

namespace IncaFc.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IncaFcDbContext _dbContext;

    public ProductRepository(IncaFcDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Product product)
    {
        _dbContext.Add(product);
        _dbContext.SaveChanges();
    }
}
