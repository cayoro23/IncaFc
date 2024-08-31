using IncaFc.Domain.Entities;

namespace IncaFc.Application.Services.Authentication.Common;

public record AuthenticationResult(User User, string Token);