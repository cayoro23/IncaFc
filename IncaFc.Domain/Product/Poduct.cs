using IncaFc.Domain.Brand.ValueObjects;
using IncaFc.Domain.Category.ValueObjects;
using IncaFc.Domain.Common.Models;
using IncaFc.Domain.Location.ValueObjects;
using IncaFc.Domain.Price.ValueObjects;
using IncaFc.Domain.Product.ValueObjects;

namespace IncaFc.Domain.Product;

public sealed class Product : AggregateRoot<ProductId>
{
    private readonly List<CategoryId> _categories = [];
    private readonly List<BrandId> _brand = [];
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<CategoryId> CategoryIds => _categories;
    public IReadOnlyList<BrandId> BrandIds => _brand;
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