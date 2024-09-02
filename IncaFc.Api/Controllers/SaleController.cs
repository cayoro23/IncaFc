using IncaFc.Application.Sales.Commands.CreateSale;
using IncaFc.Application.Sales.Commands.DeleteSale;
using IncaFc.Application.Sales.Commands.UpdateSale;
using IncaFc.Application.Sales.Queries.GetSale;
using IncaFc.Contracts.Sales;
using IncaFc.Domain.SaleAggregate;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace IncaFc.Api.Controllers;

[Route("sale")]
public class SaleController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public SaleController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSale(CreateSaleRequest request)
    {
        var command = _mapper.Map<CreateSaleCommand>(request);
        var createSaleResult = await _mediator.Send(command);

        return createSaleResult.Match(
            sale => Ok(_mapper.Map<SaleResponse>(sale)),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetSaleById(Guid id)
    {
        var query = new GetSaleQuery(id);
        var getSaleResult = await _mediator.Send(query);

        return getSaleResult.Match(
            sale => Ok(_mapper.Map<SaleResponse>(sale)),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateSale(Guid id, UpdateSalesRequest request)
    {

        var command = _mapper.Map<UpdateSaleCommand>((id, request));
        var updateSaleResult = await _mediator.Send(command);

        return updateSaleResult.Match(
            sale => Ok(_mapper.Map<SaleResponse>(sale)),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteSale(Guid id)
    {
        var command = new DeleteSaleCommand(id);
        var deleteSaleResult = await _mediator.Send(command);

        return deleteSaleResult.Match(
            result => NotFound(),
            errors => Problem(errors)
        );
    }

}