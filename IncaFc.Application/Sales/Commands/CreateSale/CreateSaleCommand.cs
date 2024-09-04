using ErrorOr;
using IncaFc.Domain.SaleAggregate;
using MediatR;

namespace IncaFc.Application.Sales.Commands.CreateSale;

public record CreateSaleCommand(
    string Name,
    bool State,
    string? Reason,
    Guid CustomerId,
    Guid UserId,
    List<SaleDetailCommand> SaleDetails
) : IRequest<ErrorOr<Sale>>;

public record SaleDetailCommand(Guid ProductId, int Quantity);
