using IncaFc.Domain.ProductAggregate;

namespace IncaFc.Application.Common.Interfaces.Persistence;

public interface IProductRepository
{
    void Add(Product product);
    public void AddRange(IEnumerable<Product> products);
    Task<Product?> GetByIdInMemoryAsync(Guid productId);
}