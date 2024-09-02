using FluentValidation;

namespace IncaFc.Application.Sales.Commands.CreateSale;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.State).NotEmpty();
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.SaleDetail).NotEmpty();
    }
}