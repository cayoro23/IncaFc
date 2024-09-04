using IncaFc.Domain.ProductAggregate;

namespace IncaFc.Application.Common.Interfaces.Persistence;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task AddRangeAsync(IEnumerable<Product> products);
    Task DeleteAsync(Product product);
    Task<Product?> GetByIdAsync(Guid productId);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdInMemoryAsync(Guid productId);
    Task UpdateAsync(Product product);
}
