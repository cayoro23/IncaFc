using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.CustomerAggregate.ValueObjects;

public class CustomerId : AgregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private CustomerId(Guid value)
    {
        Value = value;
    }

    public static CustomerId CreateUnique()
    {
        return new CustomerId(Guid.NewGuid());
    }

    public static CustomerId Create(Guid value)
    {
        return new CustomerId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}