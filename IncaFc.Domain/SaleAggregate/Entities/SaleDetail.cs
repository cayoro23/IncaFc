using IncaFc.Domain.Common.Models;
using IncaFc.Domain.ProductAggregate.ValueObjects;
using IncaFc.Domain.SaleAggregate.ValueObjects;

namespace IncaFc.Domain.SaleAggregate.Entities;

public sealed class SaleDetail : AggregateRoot<SaleDetailId, Guid>
{
    private readonly List<ProductId> _productIds = [];
    public decimal Igv { get; private set; }
    public decimal TotalBruto { get; private set; }
    public decimal TotalNeto { get; private set; }
    public IReadOnlyList<ProductId> ProductIds => _productIds.AsReadOnly();

    private SaleDetail(
        SaleDetailId saleDetailId,
        decimal igv,
        decimal totalBruto,
        decimal totalNeto,
        List<ProductId> productIds)
        : base(saleDetailId)
    {
        Igv = igv;
        TotalBruto = totalBruto;
        TotalNeto = totalNeto;
        _productIds = productIds;
    }

    public static SaleDetail Create(
        decimal igv,
        decimal totalBruto,
        decimal totalNeto,
        List<ProductId> productIds)
    {
        return new SaleDetail(
            SaleDetailId.CreateUnique(),
            igv,
            totalBruto,
            totalNeto,
            productIds
        );
    }

#pragma warning disable CS8618
    private SaleDetail()
    { }
#pragma warning restore CS8618
}