using ErrorOr;

using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Application.Sales.Queries.GetSale;
using IncaFc.Domain.SaleAggregate;
using IncaFc.Domain.Common.Errors;

using MediatR;

namespace IncaFc.Application.Sales.Commands.DeleteSale;

public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommand, ErrorOr<Sale>>
{
    private readonly ISaleRepository _saleRepository;

    public DeleteSaleCommandHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<ErrorOr<Sale>> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        // Buscar el producto por ID
        var sale = await _saleRepository.GetByIdInMemoryAsync(request.SaleId);

        // Verificar si el producto existe
        if (sale is null)
        {
            return Errors.SaleUpdate.UpdateSale;
        }

        await _saleRepository.DeleteAsync(sale);

        // Retornar el producto encontrado
        return sale;
    }
}
