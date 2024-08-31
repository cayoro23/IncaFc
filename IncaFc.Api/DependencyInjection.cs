using IncaFc.Api.Common.Errors;
using IncaFc.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace IncaFc.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, IncaFcProblemDetailsFactory>();
        services.AddMappings();

        return services;
    }
}