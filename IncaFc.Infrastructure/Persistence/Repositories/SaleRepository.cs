using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.SaleAggregate;
using IncaFc.Domain.SaleAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace IncaFc.Infrastructure.Persistence.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly IncaFcDbContext _dbContext;

    public SaleRepository(IncaFcDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Sale?> GetByIdInMemoryAsync(Guid saleId)
    {
        var sales = await GetAllAsync();
        return sales.FirstOrDefault(p => p.Id.Value == saleId);
    }

    public async Task UpdateAsync(Sale sale)
    {
        _dbContext.Sales.Update(sale);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Sale>> GetAllAsync()
    {
        return await _dbContext.Sales.ToListAsync();
    }

    public async Task AddAsync(Sale sale)
    {
        await _dbContext.AddAsync(sale);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Sale sale)
    {
        _dbContext.Sales.Remove(sale);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddDetailAsync(SaleDetail saleDetail)
    {
        await _dbContext.AddAsync(saleDetail);
        await _dbContext.SaveChangesAsync();
    }
}
