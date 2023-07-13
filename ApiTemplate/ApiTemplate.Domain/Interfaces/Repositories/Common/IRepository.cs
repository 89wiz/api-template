namespace ApiTemplate.Domain.Interfaces.Repositories.Common;

public interface IRepository<TEntity> : IWriteRepository<TEntity>, IReadRepository<TEntity> where TEntity : class
{
}
