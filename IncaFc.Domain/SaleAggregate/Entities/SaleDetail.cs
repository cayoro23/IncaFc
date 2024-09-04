using IncaFc.Domain.Common.Models;
using IncaFc.Domain.ProductAggregate.ValueObjects;
using IncaFc.Domain.SaleAggregate.ValueObjects;

namespace IncaFc.Domain.SaleAggregate.Entities
{
    public sealed class SaleDetail : AggregateRoot<SaleDetailId, Guid>
    {
        public ProductId ProductId { get; private set; }
        public int Quantity { get; private set; }

        private SaleDetail(SaleDetailId saleDetailId, ProductId productId, int quantity)
            : base(saleDetailId)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public static SaleDetail Create(ProductId productId, int quantity)
        {
            return new SaleDetail(SaleDetailId.CreateUnique(), productId, quantity);
        }

#pragma warning disable CS8618
        private SaleDetail() { }
#pragma warning restore CS8618
    }
}
