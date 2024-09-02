using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.BrandAggregate.ValueObjects;

public class BrandId : ValueObject
{
    public Guid Value { get; private set; }

    private BrandId(Guid value)
    {
        Value = value;
    }

    public static BrandId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static BrandId Create(Guid value)
    {
        return new BrandId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}