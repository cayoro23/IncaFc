using ErrorOr;
using IncaFc.Application.Authentication.Common;
using MediatR;

namespace IncaFc.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;