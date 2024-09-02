namespace IncaFc.Contracts.Customers;

public record CustomerResponse(
    string Id,
    string Name,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);