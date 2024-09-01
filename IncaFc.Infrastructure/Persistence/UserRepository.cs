using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.UserAggregate;

namespace IncaFc.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetByEmail(string email)
    {
        return _users.SingleOrDefault(x => x.Email == email);
    }
}