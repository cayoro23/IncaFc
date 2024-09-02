using IncaFc.Application.Products.Commands.CreateProduct;
using IncaFc.Application.Products.Commands.CreateProducts;
using IncaFc.Application.Products.Queries.GetProduct;
using IncaFc.Contracts.Products;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace IncaFc.Api.Controllers;

[Route("product")]
public class ProductController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public ProductController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost("single")]
    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var command = _mapper.Map<CreateProductCommand>(request);

        var createProductResult = await _mediator.Send(command);

        return createProductResult.Match(
            product => Ok(_mapper.Map<ProductResponse>(product)),
            errors => Problem(errors)
        );
    }

    [HttpPost("multiple")]
    public async Task<IActionResult> CreateProducts(List<CreateProductRequest> requests)
    {
        var command = _mapper.Map<CreateProductsCommand>(requests);

        var createProductsResult = await _mediator.Send(command);

        return createProductsResult.Match(
            products => Ok(products.Select(product => _mapper.Map<ProductResponse>(product)).ToList()),
            errors => Problem(errors)
        );
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var query = new GetProductQuery(id);

        var getProductResult = await _mediator.Send(query);

        return getProductResult.Match(
            product => Ok(_mapper.Map<ProductResponse>(product)),
            errors => Problem(errors)
        );
    }
}
