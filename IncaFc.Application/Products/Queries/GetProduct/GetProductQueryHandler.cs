using ErrorOr;

using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.ProductAggregate;

using MediatR;

namespace IncaFc.Application.Products.Queries.GetProduct;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductQuery, ErrorOr<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        // Buscar el producto por ID
        var product = await _productRepository.GetByIdInMemoryAsync(request.ProductId);

        // Verificar si el producto existe
        if (product is null)
        {
            return Error.NotFound($"Product with ID {request.ProductId} not found.");
        }

        // Retornar el producto encontrado
        return product;
    }
}
