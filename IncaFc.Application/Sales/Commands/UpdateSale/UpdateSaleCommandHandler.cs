using ErrorOr;

using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.SaleAggregate;
using IncaFc.Domain.Common.Errors;

using MediatR;

namespace IncaFc.Application.Sales.Commands.UpdateSale;

public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, ErrorOr<Sale>>
{
    private readonly ISaleRepository _saleRepository;

    public UpdateSaleCommandHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<ErrorOr<Sale>> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        // Modificar Venta
        var sale = await _saleRepository.GetByIdInMemoryAsync(request.Id);
        if (sale is null)
        {
            return Errors.SaleUpdate.UpdateSale;
        }

        // Persistir Producto
        sale.UpdateStateAndReason(request.State, request.Reason);
        await _saleRepository.UpdateAsync(sale);

        // Retornar Producto
        return sale;
    }
}
