namespace IncaFc.Contracts.Sales;

public record SaleResponse(
    Guid Id,
    string Name,
    bool State,
    string Reason,
    Guid CustomerId,
    Guid UserId,
    SaleDetailResponse SaleDetail,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record SaleDetailResponse(
    Guid Id,
    decimal Igv,
    decimal TotalBruto,
    decimal TotalNeto,
    List<Guid> ProductIds
);

public record ProductIdResponse(Guid Value);
