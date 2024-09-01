using IncaFc.Domain.Common.Models;

namespace IncaFc.Domain.Sale.ValueObjects;

public class SaleDetailId : ValueObject
{
    public Guid Value { get; }

    private SaleDetailId(Guid value)
    {
        Value = value;
    }

    public static SaleDetailId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}