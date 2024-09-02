using ErrorOr;

using IncaFc.Domain.SaleAggregate;

using MediatR;

namespace IncaFc.Application.Sales.Commands.CreateSale;

public record CreateSaleCommand(
    string Name,
    bool State,
    Guid CustomerId,
    Guid UserId,
    SaleDetailCommand SaleDetail
) : IRequest<ErrorOr<Sale>>;

public record SaleDetailCommand(
    Guid Id,
    decimal Igv,
    List<ProductIdCommand> ProductIds);

public record ProductIdCommand(Guid Value);
