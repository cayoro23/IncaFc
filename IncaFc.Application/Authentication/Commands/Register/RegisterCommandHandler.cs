using ErrorOr;

using IncaFc.Application.Authentication.Common;
using IncaFc.Application.Common.Interfaces.Authentication;
using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.Common.Errors;
using IncaFc.Domain.UserAggregate;

using MediatR;

namespace IncaFc.Application.Authentication.Commands.Register;

public class RegisterCommandHandler
    : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository
    )
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken
    )
    {
        await Task.CompletedTask;

        // 1. Validar si el usuario no existe
        if (_userRepository.GetByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2. Crear usuario (Generar unico ID) & agregarlo en la BD
        var user = User.Create(
            firstName: command.FirstName,
            lastName: command.LastName,
            email: command.Email,
            password: command.Password
        );

        _userRepository.Add(user);

        // 3. Crear Jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
