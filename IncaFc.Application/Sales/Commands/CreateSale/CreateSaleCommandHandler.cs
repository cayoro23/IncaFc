using ErrorOr;

using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.SaleAggregate;
using IncaFc.Domain.Common.Errors;

using MediatR;
using IncaFc.Domain.SaleAggregate.Entities;
using IncaFc.Domain.ProductAggregate.ValueObjects;
using IncaFc.Domain.CustomerAggregate.ValueObjects;
using IncaFc.Domain.UserAggregate.ValueObjects;

namespace IncaFc.Application.Sales.Commands.CreateSale;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, ErrorOr<Sale>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;

    public CreateSaleCommandHandler(ISaleRepository saleRepository, IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Sale>> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var productPrices = new Dictionary<Guid, decimal>();
        decimal totalBruto = 0;
        decimal exchangeRate = 3.80m;

        foreach (var productId in request.SaleDetail.ProductIds)
        {
            var product = await _productRepository.GetByIdInMemoryAsync(productId.Value);

            if (product is null)
            {
                return Errors.SaleDetailProduct.EmptySaleDetailProduct;
            }

            decimal productPriceInPEN = product.Price.Currency == "USD" ? product.Price.Amount * exchangeRate : product.Price.Amount;
            productPrices[productId.Value] = productPriceInPEN;
            totalBruto += productPriceInPEN;
        }

        decimal totalNeto = totalBruto + (totalBruto * request.SaleDetail.Igv / 100);

        // Crear Venta
        var saleDetail = SaleDetail.Create(
            igv: request.SaleDetail.Igv,
            totalBruto: totalBruto,
            totalNeto: totalNeto,
            productIds: request.SaleDetail.ProductIds.ConvertAll(p => ProductId.Create(p.Value))
        );

        var sale = Sale.Create(
            name: request.Name,
            state: request.State,
            reason: "",
            customerId: CustomerId.Create(request.CustomerId),
            userId: UserId.Create(request.UserId),
            saleDetail: saleDetail
        );

        // Persistir Producto
        await _saleRepository.AddAsync(sale);

        // Retornar Producto
        return sale;
    }
}
