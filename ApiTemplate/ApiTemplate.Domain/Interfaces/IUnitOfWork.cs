namespace ApiTemplate.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IQueryable<T> Get<T>() where T : class;
        Task BeginTransaction();
        Task Save();
        Task Rollback();
        Task Commit();
    }
}
