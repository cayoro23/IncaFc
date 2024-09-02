namespace IncaFc.Contracts.Customer;

public record CustomerResponse(
    string Id,
    string Name,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);