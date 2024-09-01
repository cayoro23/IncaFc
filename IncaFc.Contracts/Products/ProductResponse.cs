namespace IncaFc.Contracts.Products;

public record ProductResponse(
    string Id,
    string Name,
    string Description,
    int Stock,
    PriceResponse Price,
    LocationResponse Location,
    List<string> Category,
    List<string> Brand,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record PriceResponse(
    decimal Amount,
    string Currency,
    string UnitOfMeasure
);

public record LocationResponse(
    string Name,
    string Address,
    double Latitude,
    double Longitude
);