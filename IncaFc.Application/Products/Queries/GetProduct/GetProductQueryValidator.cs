using FluentValidation;

namespace IncaFc.Application.Products.Queries.GetProduct;

public class GetProductQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductQueryValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
    }
}