using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.BrandAggregate.ValueObjects;

public class BrandId : AgregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private BrandId(Guid value)
    {
        Value = value;
    }

    public static BrandId CreateUnique()
    {
        return new BrandId(Guid.NewGuid());
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