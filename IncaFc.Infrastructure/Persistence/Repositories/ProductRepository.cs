
using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.ProductAggregate;

using Microsoft.EntityFrameworkCore;

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

    public void AddRange(IEnumerable<Product> products)
    {
        _dbContext.Products.AddRange(products);
        _dbContext.SaveChanges();
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdInMemoryAsync(Guid productId)
    {
        var products = await GetAllProductsAsync();
        return products.FirstOrDefault(p => p.Id.Value == productId);
    }
}