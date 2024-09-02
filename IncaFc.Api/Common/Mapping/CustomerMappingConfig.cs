using IncaFc.Application.Customers.Commands.CreateCustomer;
using IncaFc.Contracts.Customers;
using IncaFc.Domain.CustomerAggregate;

using Mapster;

namespace IncaFc.Api.Common.Mapping;

public class CustomerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreateCustomerRequest, CreateCustomerCommand>()
            .Map(dest => dest, src => src);

        config.NewConfig<Customer, CustomerResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString());
    }
}
