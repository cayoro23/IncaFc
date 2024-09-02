using ErrorOr;

using IncaFc.Domain.SaleAggregate;

using MediatR;

namespace IncaFc.Application.Sales.Commands.UpdateSale;

public record UpdateSaleCommand(
    Guid Id,
    bool State,
    string Reason
) : IRequest<ErrorOr<Sale>>;
