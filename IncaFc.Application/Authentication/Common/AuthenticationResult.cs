using IncaFc.Domain.Entities;

namespace IncaFc.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);