using IncaFc.Application.Authentication.Commands.Register;
using IncaFc.Application.Authentication.Common;
using IncaFc.Application.Authentication.Queries.Login;
using IncaFc.Contracts.Authentication;

using Mapster;

namespace IncaFc.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User)
            .Map(dest => dest.Id, src => src.User.Id.Value);
    }
}