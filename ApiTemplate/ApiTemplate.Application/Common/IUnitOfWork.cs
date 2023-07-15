using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Application.Common
{
    public interface IUnitOfWork
    {
        DbSet<T> DbSet<T>() where T : class;
        Task BeginTransaction();
        Task Save();
        Task Rollback();
        Task Commit();
    }
}
