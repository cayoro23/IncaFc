using FluentValidation;

using IncaFc.Application.Products.Commands.CreateProducts;

namespace IncaFc.Application.Products.Commands.CreateProduct;

public class CreateProductsCommandValidator : AbstractValidator<CreateProductsCommand>
{
    public CreateProductsCommandValidator()
    {
        RuleFor(x => x.Products).NotEmpty();

        // Validar cada producto dentro de la lista
        RuleForEach(x => x.Products).ChildRules(product =>
        {
            product.RuleFor(x => x.Name).NotEmpty();
            product.RuleFor(x => x.Description).NotEmpty();
            product.RuleFor(x => x.Stock).NotEmpty();
            product.RuleFor(x => x.Price).NotEmpty();
            product.RuleFor(x => x.Price.Amount).NotEmpty();
            product.RuleFor(x => x.Price.Currency).NotEmpty();
            product.RuleFor(x => x.Price.UnitOfMeasure).NotEmpty();
            product.RuleFor(x => x.Location).NotEmpty();
            product.RuleFor(x => x.Location.Name).NotEmpty();
            product.RuleFor(x => x.Location.Address).NotEmpty();
            product.RuleFor(x => x.Location.Latitude).NotEmpty();
            product.RuleFor(x => x.Location.Longitude).NotEmpty();
        });
    }
}