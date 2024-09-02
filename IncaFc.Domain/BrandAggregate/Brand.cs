using IncaFc.Domain.BrandAggregate.ValueObjects;
using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.BrandAggregate;

public sealed class Brand : AggregateRoot<BrandId, Guid>
{
    public string Name { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

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

#pragma warning disable CS8618 
    private Brand()
    { }
#pragma warning restore CS8618 
}