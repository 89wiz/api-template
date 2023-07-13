using ApiTemplate.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace ApiTemplate.Infra.Data.Context;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly Context _dbContext;

    private IDbContextTransaction? _transaction;
    private bool _disposed;

    public UnitOfWork(Context context)
    {
        _dbContext = context;
    }

    public IQueryable<T> Get<T>() where T : class
    {
        return _dbContext.Set<T>();
    }

    public async Task BeginTransaction()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
        _disposed = false;
    }

    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task Commit()
    {
        try
        {
            await Save();
            await _transaction.CommitAsync();
        }
        catch(Exception)
        {
            await Rollback();
            throw;
        }
    }

    public async Task Rollback()
    {
        await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed && disposing)
            _dbContext.Dispose();

        this._disposed = true;
    }

}
