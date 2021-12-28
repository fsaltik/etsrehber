using Microsoft.EntityFrameworkCore;
using Rehber.Infrastructure.Data;
using Rehber.Infrastructure.Interfaces;
using Rehber.Infrastructure.Models;

namespace Rehber.Infrastructure.Repositories;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity:BaseEntity
{
    private readonly DataContext _dbContext;

    public GenericRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().AsNoTracking();
    }

    public  async Task<TEntity?> GetById(Guid id)
    {
        return await _dbContext.Set<TEntity>().AsNoTracking()
            .FirstOrDefaultAsync(e => e.UUID == id);
    }

    public async Task Create(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update( TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await GetById(id);
        if (entity != null)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}