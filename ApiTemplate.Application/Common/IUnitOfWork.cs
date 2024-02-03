using Microsoft.EntityFrameworkCore;
using AsyncTask = System.Threading.Tasks.Task;

namespace ApiTemplate.Application.Common;

public interface IUnitOfWork
{
    DbSet<T> DbSet<T>() where T : class;
    AsyncTask BeginTransaction(CancellationToken cancellationToken = default);
    AsyncTask Save(CancellationToken cancellationToken = default);
    AsyncTask Rollback(CancellationToken cancellationToken = default);
    AsyncTask Commit(CancellationToken cancellationToken = default);
}
