using ErrorOr;
using IncaFc.Application.Services.Authentication.Common;

namespace IncaFc.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}