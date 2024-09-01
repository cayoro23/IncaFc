using IncaFc.Domain.UserAggregate;

namespace IncaFc.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
