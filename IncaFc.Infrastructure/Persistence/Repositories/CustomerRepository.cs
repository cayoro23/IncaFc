using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.CustomerAggregate;

using Microsoft.EntityFrameworkCore;

namespace IncaFc.Infrastructure.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IncaFcDbContext _dbContext;

    public CustomerRepository(IncaFcDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Customer customer)
    {
        _dbContext.Add(customer);
        _dbContext.SaveChanges();
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdInMemoryAsync(Guid customerId)
    {
        var customers = await GetAllCustomersAsync();
        return customers.FirstOrDefault(p => p.Id.Value == customerId);
    }
}