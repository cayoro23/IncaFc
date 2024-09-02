using FluentValidation;

using IncaFc.Application.Sales.Queries.GetSale;

namespace IncaFc.Application.Sales.Commands.DeleteSale;

public class DeleteSaleCommandValidator : AbstractValidator<GetSaleQuery>
{
    public DeleteSaleCommandValidator()
    {
        RuleFor(x => x.SaleId).NotEmpty();
    }
}