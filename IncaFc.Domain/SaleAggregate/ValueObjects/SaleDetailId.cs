using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.SaleAggregate.ValueObjects;

public class SaleDetailId : AgregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private SaleDetailId(Guid value)
    {
        Value = value;
    }

    public static SaleDetailId CreateUnique()
    {
        return new SaleDetailId(Guid.NewGuid());
    }

    public static SaleDetailId Create(Guid value)
    {
        return new SaleDetailId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}