using IncaFc.Domain.BrandAggregate;
using IncaFc.Domain.CategoryAggregate;
using IncaFc.Domain.Common.Models;
using IncaFc.Domain.ProductAggregate.ValueObjects;

namespace IncaFc.Domain.ProductAggregate;

public sealed class Product : AggregateRoot<ProductId>
{
    private readonly List<Category> _categories = [];
    private readonly List<Brand> _brands = [];
    public string Name { get; }
    public string Description { get; }
    public int Stock { get; }
    public IReadOnlyList<Category> Category => _categories.AsReadOnly();
    public IReadOnlyList<Brand> Brand => _brands.AsReadOnly();
    public Price Price { get; }
    public Location Location { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Product(
        ProductId productId,
        string name,
        string description,
        int stock,
        Price price,
        Location location,
        List<Category> category,
        List<Brand> brands,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(productId)
    {
        Name = name;
        Description = description;
        Stock = stock;
        Price = price;
        Location = location;
        _categories = category;
        _brands = brands;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Product Create(
        string name,
        string description,
        int stock,
        Price price,
        Location location,
        List<Category>? category,
        List<Brand>? brands
    )
    {
        return new Product(
            ProductId.CreateUnique(),
            name,
            description,
            stock,
            price,
            location,
            category ?? [],
            brands ?? [],
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
