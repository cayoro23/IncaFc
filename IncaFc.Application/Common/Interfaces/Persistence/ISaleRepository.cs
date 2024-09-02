using IncaFc.Domain.SaleAggregate;

namespace IncaFc.Application.Common.Interfaces.Persistence;

public interface ISaleRepository
{
    Task<Sale?> GetByIdInMemoryAsync(Guid saleId);
    Task<IEnumerable<Sale>> GetAllAsync();
    Task AddAsync(Sale sale);
    Task UpdateAsync(Sale sale);
    Task DeleteAsync(Sale sale);
}