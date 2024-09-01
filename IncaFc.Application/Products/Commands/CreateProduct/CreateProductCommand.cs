using ErrorOr;
using IncaFc.Domain.ProductAggregate;
using MediatR;

namespace IncaFc.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Description,
    PriceCommand Price,
    LocationCommand Location,
    CategoryCommand? Category,
    BrandCommand? Brand
) : IRequest<ErrorOr<Product>>;

public record PriceCommand(decimal Amount, string Currency, string UnitOfMeasure);

public record LocationCommand(string Address, int Stock);

public record CategoryCommand(string Name);

public record BrandCommand(string Name);
