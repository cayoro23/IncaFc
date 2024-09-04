using IncaFc.Domain.BrandAggregate.ValueObjects;
using IncaFc.Domain.CategoryAggregate.ValueObjects;
using IncaFc.Domain.Common.Models;
using IncaFc.Domain.ProductAggregate.ValueObjects;

namespace IncaFc.Domain.ProductAggregate;

public sealed class Product : AggregateRoot<ProductId, Guid>
{
    private readonly List<CategoryId> _categoryIds = [];
    private readonly List<BrandId> _brandIds = [];
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Stock { get; private set; }
    public IReadOnlyList<CategoryId> CategoryIds => _categoryIds.AsReadOnly();
    public IReadOnlyList<BrandId> BrandIds => _brandIds.AsReadOnly();
    public Price Price { get; private set; }
    public Location Location { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Product(
        ProductId productId,
        string name,
        string description,
        int stock,
        Price price,
        Location location,
        List<CategoryId> categoryIds,
        List<BrandId> brandIds,
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
        _categoryIds = categoryIds;
        _brandIds = brandIds;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public void UpdateProductStock(int stock)
    {
        Stock = stock;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public static Product Create(
        string name,
        string description,
        int stock,
        Price price,
        Location location,
        List<CategoryId>? categoryIds,
        List<BrandId>? brandIds
    )
    {
        return new Product(
            ProductId.CreateUnique(),
            name,
            description,
            stock,
            price,
            location,
            categoryIds ?? [],
            brandIds ?? [],
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

#pragma warning disable CS8618
    private Product() { }
#pragma warning restore CS8618
}
