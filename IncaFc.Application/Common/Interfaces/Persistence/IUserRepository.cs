using IncaFc.Domain.Entities;

namespace IncaFc.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetByEmail(string email);
    void Add(User user);
}