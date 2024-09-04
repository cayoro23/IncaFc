namespace IncaFc.Contracts.Sales;

using System;
using System.Collections.Generic;

public record CreateSaleRequest(
    string Name,
    bool State,
    string? Reason,
    Guid CustomerId,
    Guid UserId,
    DateTime CreatedDateTime,
    List<SaleDetailRequest> SaleDetails
);

public record SaleDetailRequest(Guid ProductId, int Quantity);
