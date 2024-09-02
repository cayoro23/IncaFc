using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.UserAggregate.ValueObjects;

public class UserId : AgregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

    public static UserId Create(Guid value)
    {
        return new UserId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}