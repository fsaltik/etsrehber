using Rehber.Infrastructure.Models;

namespace Rehber.Infrastructure.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> GetAll();
    Task<TEntity?> GetById(Guid id);
    Task Create(TEntity entity);
    Task Update(Guid id,TEntity entity);
    Task Delete(Guid id);
}