namespace IncaFc.Contracts.Products;

public record ProductResponse(
    string Id,
    string Name,
    string Description,
    PriceResponse Price,
    LocationResponse Location,
    List<string> Category,
    List<string> Brand,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record PriceResponse(
    string Id,
    decimal Amount,
    string Currency,
    string UnitOfMeasure
);

public record LocationResponse(
    string Id,
    string Address,
    int Stock
);