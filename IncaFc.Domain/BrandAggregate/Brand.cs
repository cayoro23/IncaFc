using IncaFc.Domain.BrandAggregate.ValueObjects;
using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.BrandAggregate;

public sealed class Brand : AggregateRoot<BrandId>
{
    public string Name { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Brand(
        BrandId brandId,
        string name,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(brandId)
    {
        Name = name;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Brand Create(
        string name)
    {
        return new Brand(
            BrandId.CreateUnique(),
            name,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}