using IncaFc.Domain.CustomerAggregate;

namespace IncaFc.Application.Common.Interfaces.Persistence;

public interface ICustomerRepository
{
    void Add(Customer customer);
    Task<Customer?> GetByIdInMemoryAsync(Guid customerId);
}