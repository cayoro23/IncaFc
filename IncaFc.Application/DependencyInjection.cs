using ErrorOr;
using IncaFc.Application.Authentication.Commands.Register;
using IncaFc.Application.Authentication.Common;
using IncaFc.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IncaFc.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped<
            IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
            ValidateRegisterCommandBehavior>();

        return services;    
    }
}