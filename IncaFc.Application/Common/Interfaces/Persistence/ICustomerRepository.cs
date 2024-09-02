using IncaFc.Domain.CustomerAggregate;

namespace IncaFc.Application.Common.Interfaces.Persistence;

public interface ICustomerRepository
{
    void Add(Customer product);
    Task<Customer?> GetByIdInMemoryAsync(Guid productId);
}