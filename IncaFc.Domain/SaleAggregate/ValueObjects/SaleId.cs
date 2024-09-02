using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.SaleAggregate.ValueObjects;

public class SaleId : AgregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private SaleId(Guid value)
    {
        Value = value;
    }

    public static SaleId CreateUnique()
    {
        return new SaleId(Guid.NewGuid());
    }

    public static SaleId Create(Guid value)
    {
        return new SaleId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}