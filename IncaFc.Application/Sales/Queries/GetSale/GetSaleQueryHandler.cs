using ErrorOr;

using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.SaleAggregate;
using IncaFc.Domain.Common.Errors;

using MediatR;

namespace IncaFc.Application.Sales.Queries.GetSale;

public class GetSaleQueryHandler : IRequestHandler<GetSaleQuery, ErrorOr<Sale>>
{
    private readonly ISaleRepository _saleRepository;

    public GetSaleQueryHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<ErrorOr<Sale>> Handle(GetSaleQuery request, CancellationToken cancellationToken)
    {
        // Buscar el producto por ID
        var sale = await _saleRepository.GetByIdInMemoryAsync(request.SaleId);

        // Verificar si el producto existe
        if (sale is null)
        {
            return Errors.SaleGet.GetSale;
        }

        // Retornar el producto encontrado
        return sale;
    }
}
