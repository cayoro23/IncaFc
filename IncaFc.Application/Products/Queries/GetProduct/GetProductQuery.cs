using ErrorOr;

using IncaFc.Domain.ProductAggregate;

using MediatR;

namespace IncaFc.Application.Products.Queries.GetProduct;

public record GetProductByIdQuery(Guid ProductId) : IRequest<ErrorOr<Product>>;