using IncaFc.Domain.ProductAggregate;

namespace IncaFc.Application.Common.Interfaces.Persistence;

public interface IProductRepository
{
    void Add(Product product);
    Task<Product?> GetByIdInMemoryAsync(Guid productId);
}