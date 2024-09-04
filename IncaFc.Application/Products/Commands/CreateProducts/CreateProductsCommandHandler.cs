using ErrorOr;
using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.ProductAggregate;
using IncaFc.Domain.ProductAggregate.ValueObjects;
using MediatR;

namespace IncaFc.Application.Products.Commands.CreateProducts;

public class CreateProductsCommandHandler
    : IRequestHandler<CreateProductsCommand, ErrorOr<List<Product>>>
{
    private readonly IProductRepository _productRepository;

    public CreateProductsCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<List<Product>>> Handle(
        CreateProductsCommand request,
        CancellationToken cancellationToken
    )
    {
        var products = new List<Product>();

        foreach (var productItem in request.Products)
        {
            var product = Product.Create(
                name: productItem.Name,
                description: productItem.Description,
                stock: productItem.Stock,
                price: Price.Create(
                    productItem.Price.Amount,
                    productItem.Price.Currency,
                    productItem.Price.UnitOfMeasure
                ),
                location: Location.Create(
                    productItem.Location.Name,
                    productItem.Location.Address,
                    productItem.Location.Latitude,
                    productItem.Location.Longitude
                ),
                categoryIds: [],
                brandIds: []
            );

            products.Add(product);
        }

        await _productRepository.AddRangeAsync(products);

        return products;
    }
}
