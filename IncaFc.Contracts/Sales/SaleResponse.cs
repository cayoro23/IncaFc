namespace IncaFc.Contracts.Sales;

public record SaleResponse(
    Guid SaleId,
    string Name,
    bool State,
    string? Reason,
    Guid CustomerId,
    Guid UserId,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime,
    List<SaleDetailResponse> SaleDetails,
    decimal Total,
    decimal Igv
);

public record SaleDetailResponse(Guid ProductId, int Quantity);
