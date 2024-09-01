using ErrorOr;
using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.ProductAggregate;
using IncaFc.Domain.ProductAggregate.Entities;
using MediatR;

namespace IncaFc.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Product>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken
    )
    {
        await Task.CompletedTask;
        // Crear Producto
        var product = Product.Create(
            name: request.Name,
            description: request.Description,
            price: Price.Create(
                request.Price.Amount,
                request.Price.Currency,
                request.Price.UnitOfMeasure
            ),
            location: Location.Create(request.Location.Address, request.Location.Stock),
            category: [],
            brands: []
        );

        // Persistir Producto
        _productRepository.Add(product);

        // Retornar Producto
        return product;
    }
}
