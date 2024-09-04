using ErrorOr;
using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.Common.Errors;
using IncaFc.Domain.CustomerAggregate.ValueObjects;
using IncaFc.Domain.ProductAggregate;
using IncaFc.Domain.ProductAggregate.ValueObjects;
using IncaFc.Domain.SaleAggregate;
using IncaFc.Domain.SaleAggregate.Entities;
using IncaFc.Domain.SaleAggregate.ValueObjects;
using IncaFc.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace IncaFc.Application.Sales.Commands.CreateSale;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, ErrorOr<Sale>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;

    public CreateSaleCommandHandler(
        ISaleRepository saleRepository,
        IProductRepository productRepository
    )
    {
        _saleRepository = saleRepository;
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Sale>> Handle(
        CreateSaleCommand request,
        CancellationToken cancellationToken
    )
    {
        List<Product> productSales = new List<Product>();
        List<SaleDetail> saleDetails = new List<SaleDetail>();
        decimal totalBruto = 0m;
        const decimal exchangeRate = 3.7m;
        const decimal igv = 18;

        foreach (var detail in request.SaleDetails)
        {
            Product? product = await _productRepository.GetByIdInMemoryAsync(detail.ProductId);

            if (product is null)
            {
                return Errors.CreateSale.EmptySaleDetailProduct;
            }

            productSales.Add(product);
        }

        foreach (var detail in request.SaleDetails)
        {
            var saleDetail = SaleDetail.Create(
                productId: ProductId.Create(detail.ProductId),
                quantity: detail.Quantity
            );

            saleDetails.Add(saleDetail);
        }

        for (int i = 0; i < productSales.Count; i++)
        {
            var product = productSales[i];
            var detail = request.SaleDetails[i];

            if (product.Stock < detail.Quantity)
            {
                return Errors.CreateSale.OutOfStock;
            }

            decimal productPriceInPEN =
                product.Price.Currency == "USD"
                    ? product.Price.Amount * exchangeRate
                    : product.Price.Amount;

            totalBruto += productPriceInPEN * detail.Quantity;
        }

        decimal total = totalBruto + (totalBruto * igv / 100);

        foreach (var detail in saleDetails)
        {
            await _saleRepository.AddDetailAsync(detail);
        }

        var sale = Sale.Create(
            name: request.Name,
            state: request.State,
            reason: request.Reason ?? "",
            customerId: CustomerId.Create(request.CustomerId),
            userId: UserId.Create(request.UserId),
            total: total,
            saleDetails: saleDetails
        );

        await _saleRepository.AddAsync(sale);

        for (int i = 0; i < productSales.Count; i++)
        {
            var product = productSales[i];
            var detail = request.SaleDetails[i];
            var newStock = product.Stock - detail.Quantity;

            product.UpdateProductStock(newStock);
            await _productRepository.UpdateAsync(product);
        }

        return sale;
    }
}
