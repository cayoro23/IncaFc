using IncaFc.Domain.Common.Models;
using IncaFc.Domain.Product.ValueObjects;
using IncaFc.Domain.Sale.ValueObjects;

namespace IncaFc.Domain.Sale.Entities;

public sealed class SaleDetail : AggregateRoot<SaleDetailId>
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
}