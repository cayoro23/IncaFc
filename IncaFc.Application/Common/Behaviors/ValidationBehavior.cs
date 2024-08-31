using ErrorOr;
using IncaFc.Application.Authentication.Commands.Register;
using IncaFc.Application.Authentication.Common;
using MediatR;

namespace IncaFc.Application.Common.Behaviors;

public class ValidateRegisterCommandBehavior :
    IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand request,
        RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next,
        CancellationToken cancellationToken)
    {
        // Se ejecutra antes del controlador
        var result = await next();
        // Se ejecutara despues del controlador

        return result;
    }
}
