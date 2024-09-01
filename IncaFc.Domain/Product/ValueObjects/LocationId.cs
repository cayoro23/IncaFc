using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.Product.ValueObjects;

public class LocationId : ValueObject
{
    public Guid Value { get; }

    private LocationId(Guid value)
    {
        Value = value;
    }

    public static LocationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}