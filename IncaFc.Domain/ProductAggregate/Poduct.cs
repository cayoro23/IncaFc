using IncaFc.Domain.BrandAggregate.ValueObjects;
using IncaFc.Domain.CategoryAggregate.ValueObjects;
using IncaFc.Domain.Common.Models;
using IncaFc.Domain.ProductAggregate.ValueObjects;

namespace IncaFc.Domain.ProductAggregate;

public sealed class Product : AggregateRoot<ProductId>
{
    private readonly List<CategoryId> _categories = [];
    private readonly List<BrandId> _brand = [];
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<CategoryId> CategoryIds => _categories.AsReadOnly();
    public IReadOnlyList<BrandId> BrandIds => _brand.AsReadOnly();
    public PriceId PriceId { get; }
    public LocationId LocationId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Product(
        ProductId productId,
        string name,
        string description,
        PriceId priceId,
        LocationId locationId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(productId)
    {
        Name = name;
        Description = description;
        PriceId = priceId;
        LocationId = locationId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Product Create(
        string name,
        string description,
        PriceId priceId,
        LocationId locationId)
    {
        return new Product(
            ProductId.CreateUnique(),
            name,
            description,
            priceId,
            locationId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}