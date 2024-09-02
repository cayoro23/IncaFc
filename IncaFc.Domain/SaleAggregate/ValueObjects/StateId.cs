using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.SaleAggregate.ValueObjects;

public class StateId : AgregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private StateId(Guid value)
    {
        Value = value;
    }

    public static StateId CreateUnique()
    {
        return new StateId(Guid.NewGuid());
    }

    public static StateId Create(Guid value)
    {
        return new StateId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}