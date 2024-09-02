using FluentValidation;

namespace IncaFc.Application.Sales.Queries.GetSale;

public class GetSaleQueryValidator : AbstractValidator<GetSaleQuery>
{
    public GetSaleQueryValidator()
    {
        RuleFor(x => x.SaleId).NotEmpty();
    }
}