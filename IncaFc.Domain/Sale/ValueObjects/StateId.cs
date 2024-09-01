using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.Sale.ValueObjects;

public class StateId : ValueObject
{
    public Guid Value { get; }

    private StateId(Guid value)
    {
        Value = value;
    }

    public static StateId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}