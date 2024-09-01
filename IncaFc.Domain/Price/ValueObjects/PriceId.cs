using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.Price.ValueObjects;

public class PriceId : ValueObject
{
    public Guid Value { get; }

    private PriceId(Guid value)
    {
        Value = value;
    }

    public static PriceId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}