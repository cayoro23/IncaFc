using ErrorOr;

using IncaFc.Domain.ProductAggregate;

using MediatR;

namespace IncaFc.Application.Products.Queries.GetProduct;

public record GetProductQuery(Guid ProductId) : IRequest<ErrorOr<Product>>;