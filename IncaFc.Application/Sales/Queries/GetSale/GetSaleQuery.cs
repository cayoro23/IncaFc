using ErrorOr;

using IncaFc.Domain.SaleAggregate;

using MediatR;

namespace IncaFc.Application.Sales.Queries.GetSale;

public record GetSaleQuery(Guid SaleId) : IRequest<ErrorOr<Sale>>;