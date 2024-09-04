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

    public async Task AddAsync(Product product)
    {
        await _dbContext.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<Product> products)
    {
        await _dbContext.Products.AddRangeAsync(products);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid productId)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id.Value == productId);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdInMemoryAsync(Guid productId)
    {
        var products = await GetAllAsync();
        return products.FirstOrDefault(p => p.Id.Value == productId);
    }

    public async Task UpdateAsync(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }
}
