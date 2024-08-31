using ErrorOr;
using IncaFc.Application.Services.Authentication.Common;

namespace IncaFc.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}