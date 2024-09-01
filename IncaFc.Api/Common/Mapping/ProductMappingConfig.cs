using IncaFc.Application.Products.Commands.CreateProduct;
using IncaFc.Contracts.Products;
using IncaFc.Domain.ProductAggregate;

using Mapster;

using Price = IncaFc.Domain.ProductAggregate.Entities.Price;
using Location = IncaFc.Domain.ProductAggregate.Entities.Location;

namespace IncaFc.Api.Common.Mapping;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreateProductRequest, CreateProductCommand>()
            .Map(dest => dest, src => src);

        config.NewConfig<Product, ProductResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Category, src => src.Category.Select(category => category.Id.Value))
            .Map(dest => dest.Brand, src => src.Brand.Select(brand => brand.Id.Value));

        config.NewConfig<Price, PriceResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Location, LocationResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
