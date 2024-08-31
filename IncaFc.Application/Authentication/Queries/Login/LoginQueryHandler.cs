using IncaFc.Application.Common.Interfaces.Authentication;
using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Application.Authentication.Common;
using IncaFc.Domain.Common.Errors;
using IncaFc.Domain.Entities;
using ErrorOr;
using MediatR;

namespace IncaFc.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validar que el usuario existe
        if (_userRepository.GetByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 2. Validar que la contraseña sea correcta
        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 3. Crear Jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}
