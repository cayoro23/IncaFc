using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.CancellationAggregate.ValueObjects;

public class CancellationId : ValueObject
{
    public Guid Value { get; }

    private CancellationId(Guid value)
    {
        Value = value;
    }

    public static CancellationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}