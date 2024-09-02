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

        config.NewConfig<(Guid Id, UpdateSalesRequest Request), UpdateSaleCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Sale, SaleResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.State, src => src.State)
            .Map(dest => dest.Reason, src => src.Reason ?? "")
            .Map(dest => dest.CustomerId, src => src.CustomerId.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.SaleDetail, src => new SaleDetailResponse(
                src.SaleDetail.Id.Value,
                src.SaleDetail.Igv,
                src.SaleDetail.TotalBruto,
                src.SaleDetail.TotalNeto,
                src.SaleDetail.ProductIds.Select(p => p.Value).ToList()
            ))
            .Map(dest => dest.CreatedDateTime, src => src.CreatedDateTime)
            .Map(dest => dest.UpdatedDateTime, src => src.UpdatedDateTime);
    }
}