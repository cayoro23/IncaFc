using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.ProductAggregate;

namespace IncaFc.Infrastructure.Persistence;

public class PRoductRepository : IProductRepository
{
    private static readonly List<Product> _products = [];

    public void Add(Product product)
    {
        _products.Add(product);
    }
}
