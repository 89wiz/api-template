namespace ApiTemplate.Domain.Interfaces.Repositories.Common;

public interface IWriteRepository<TEntity>
    where TEntity : class
{
    Task Add(TEntity entity);
    Task Add(ICollection<TEntity> collection);
    Task Update(TEntity entity);
    //Task Update(TEntity entity, params Expression<Func<TEntity, object>>[] excludeProperties);
    Task Delete(TEntity entity);
    Task Delete(ICollection<TEntity> collection);
    Task SetAsAdded(TEntity entity);
}