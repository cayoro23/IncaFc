using FluentValidation;

namespace IncaFc.Application.Products.Queries.GetProduct;

public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
{
    public GetProductQueryValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
    }
}