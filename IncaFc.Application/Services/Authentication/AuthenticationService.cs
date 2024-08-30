using IncaFc.Application.Common.Interfaces.Authentication;
using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.Entities;

namespace IncaFc.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validar si el usuario no existe
        if (_userRepository.GetByEmail(email) is not null)
        {
            throw new Exception("Este usuario con el correo electronico ya existe.");
        }

        // 2. Crear usuario (Generar unico ID) & agregarlo en la BD
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // 3. Crear Jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validar que el usuario existe
        if (_userRepository.GetByEmail(email) is not User user)
        {
            throw new Exception("EL usuario con el correo no existe");
        }

        // 2. Validar que la contraseña sea correcta
        if (user.Password != password)
        {
            throw new Exception("Contraseña incorrecta");
        }

        // 3. Crear Jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}