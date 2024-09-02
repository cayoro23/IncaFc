using IncaFc.Application.Products.Commands.CreateProduct;
using IncaFc.Contracts.Products;
using IncaFc.Domain.ProductAggregate;

using Mapster;

using Price = IncaFc.Domain.ProductAggregate.ValueObjects.Price;
using Location = IncaFc.Domain.ProductAggregate.ValueObjects.Location;

namespace IncaFc.Api.Common.Mapping;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreateProductRequest, CreateProductCommand>()
            .Map(dest => dest, src => src);

        config.NewConfig<Product, ProductResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.CategoryIds, src => src.CategoryIds.Select(categoryId => categoryId.Value))
            .Map(dest => dest.BrandIds, src => src.BrandIds.Select(brandId => brandId.Value));

        config.NewConfig<Price, PriceResponse>()
            .Map(dest => dest, src => src);

        config.NewConfig<Location, LocationResponse>()
            .Map(dest => dest, src => src);
    }
}
