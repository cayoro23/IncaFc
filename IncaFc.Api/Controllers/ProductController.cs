using IncaFc.Application.Products.Commands.CreateProduct;
using IncaFc.Contracts.Products;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace IncaFc.Api.Controllers;

[Route("products")]
public class ProductController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public ProductController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateProductRequest request)
    {
        var command = _mapper.Map<CreateProductCommand>(request);

        var createProductResult = await _mediator.Send(command);

        return createProductResult.Match(
            product => Ok(_mapper.Map<ProductResponse>(product)),
            errors => Problem(errors)
        );
    }
}
