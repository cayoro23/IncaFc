namespace IncaFc.Contracts.Products;

public record CreateProductRequest(string Name, string Description, Price Price, Location Location);

public record Price(decimal Amount, string Currency, string UnitOfMeasure);

public record Location(string Address, int Stock);
