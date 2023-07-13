using System.Linq.Expressions;

namespace ApiTemplate.Domain.Interfaces.Repositories.Common;

public interface IReadRepository<TEntity>
    where TEntity : class
{
    Task<TEntity?> Get(int id, bool @readonly = true);
    Task<IQueryable<TEntity>> GetAll(bool @readonly = true);
    Task<IQueryable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate, bool @readonly = true);

    // TODO find better explicit alternative for single query
    //Task<IQueryable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate, bool @readonly = true, bool @singleQuery = true, params Expression<Func<TEntity, object>>[] includeProperties);
}