using IncaFc.Domain.Entities;

namespace IncaFc.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}