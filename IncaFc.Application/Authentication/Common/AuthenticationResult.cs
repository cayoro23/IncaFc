using IncaFc.Domain.UserAggregate;

namespace IncaFc.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);
