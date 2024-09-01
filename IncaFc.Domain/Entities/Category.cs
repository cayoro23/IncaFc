namespace IncaFc.Domain.Entities;

public class Category
{
    public Guid CategoryId { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public List<Product> Products { get; set; } = null!;
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}
