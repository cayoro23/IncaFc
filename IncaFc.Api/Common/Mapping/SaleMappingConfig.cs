using IncaFc.Application.Sales.Commands.CreateSale;
using IncaFc.Application.Sales.Commands.UpdateSale;
using IncaFc.Contracts.Sales;
using IncaFc.Domain.SaleAggregate;

using Mapster;

namespace IncaFc.Api.Common.Mapping;

public class SaleMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateSaleRequest, CreateSaleCommand>()
            .Map(dest => dest, src => src);

        config.NewConfig<(Guid Id, UpdateSaleRequest Request), UpdateSaleCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest, src => src.Request);

    }
}