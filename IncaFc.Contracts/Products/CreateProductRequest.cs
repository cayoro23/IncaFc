namespace IncaFc.Contracts.Products;

public record CreateProductRequest(string Name, string Description, int Stock, Price Price, Location Location);

public record Price(decimal Amount, string Currency, string UnitOfMeasure);

public record Location(string Name, string Address, double Latitude, double Longitude);
