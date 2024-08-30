using IncaFc.Domain.Entities;

namespace IncaFc.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);