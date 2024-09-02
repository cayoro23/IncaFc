using IncaFc.Domain.Common.Models;
using IncaFc.Domain.ProductAggregate.ValueObjects;
using IncaFc.Domain.SaleAggregate.ValueObjects;

namespace IncaFc.Domain.SaleAggregate.Entities;

public sealed class SaleDetail : AggregateRoot<SaleDetailId, Guid>
{
    private readonly List<ProductId> _products = [];
    public decimal IGV { get; }
    public decimal Total { get; }
    public IReadOnlyList<ProductId> ProductIds => _products.AsReadOnly();

    private SaleDetail(
        SaleDetailId saleDetailId,
        decimal igv,
        decimal toal)
        : base(saleDetailId)
    {
        IGV = igv;
        Total = toal;
    }

    public static SaleDetail Create(
        decimal igv,
        decimal total)
    {
        return new SaleDetail(
            SaleDetailId.CreateUnique(),
            igv,
            total
        );
    }

#pragma warning disable CS8618
    private SaleDetail()
    { }
#pragma warning restore CS8618
}