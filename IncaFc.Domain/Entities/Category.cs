namespace IncaFc.Domain.Entities;

public class Category
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = null!;

    public List<Product> Products { get; set; } = null!;
}
