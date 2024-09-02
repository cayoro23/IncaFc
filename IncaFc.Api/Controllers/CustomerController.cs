using IncaFc.Application.Customers.Commands.CreateCustomer;
using IncaFc.Application.Customers.Queries.GetCustomer;
using IncaFc.Application.Products.Commands.CreateProduct;
using IncaFc.Contracts.Customer;
using IncaFc.Contracts.Products;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace IncaFc.Api.Controllers;

[Route("customers")]
public class CustomerController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public CustomerController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
    {
        var command = _mapper.Map<CreateCustomerCommand>(request);

        var createCustomerResult = await _mediator.Send(command);

        return createCustomerResult.Match(
            customer => Ok(_mapper.Map<CustomerResponse>(customer)),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var query = new GetCustomerQuery(id);

        var getCustomerResult = await _mediator.Send(query);

        return getCustomerResult.Match(
            customer => Ok(_mapper.Map<CustomerResponse>(customer)),
            errors => Problem(errors)
        );
    }
}
