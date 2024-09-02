using FluentValidation;

using IncaFc.Application.Customers.Queries.GetCustomer;

namespace IncaFc.Application.Products.Queries.GetProduct;

public class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerQueryValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}