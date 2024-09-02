using ErrorOr;

using IncaFc.Domain.SaleAggregate;

using MediatR;

namespace IncaFc.Application.Sales.Commands.DeleteSale;

public record DeleteSaleCommand(Guid SaleId) : IRequest<ErrorOr<Sale>>;