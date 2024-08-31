using ErrorOr;
using IncaFc.Application.Authentication.Common;
using MediatR;

namespace IncaFc.Application.Authentication.Queries.Login;

public record class LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;