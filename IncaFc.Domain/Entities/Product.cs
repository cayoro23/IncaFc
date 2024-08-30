namespace IncaFc.Domain.Entities;

public class Product
{
    public Guid ProducId { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }

    public Category Category { get; set; } = null!;
    public Brand Brand { get; set; } = null!;
    public List<Price> Prices { get; set; } = null!;
    public List<Location> Locations { get; set; } = null!;
}
