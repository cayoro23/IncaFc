using IncaFc.Application.Common.Interfaces.Authentication;
using IncaFc.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace IncaFc.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        
        return services;
    }
}