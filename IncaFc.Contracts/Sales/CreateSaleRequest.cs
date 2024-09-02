namespace IncaFc.Contracts.Sales;

public record CreateSaleRequest(
    string Name,
    bool State,
    Guid CustomerId,
    Guid UserId,
    CreateSaleDetailRequest SaleDetail
);

public record CreateSaleDetailRequest(
    Guid Id,
    decimal Igv,
    List<CreateProductIdRequest> ProductIds);

public record CreateProductIdRequest(Guid Value);