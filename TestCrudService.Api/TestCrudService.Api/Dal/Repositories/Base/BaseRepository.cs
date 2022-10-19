using Microsoft.EntityFrameworkCore;

namespace TestCrudService.Api.Dal.Repositories.Base;

internal abstract class BaseRepository<TContext> where TContext : DbContext
{
    private readonly TContext _context;

    protected BaseRepository(TContext context)
    {
        _context = context;
        _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    internal async Task DoSaveAsync(Action<TContext, CancellationToken> action,
        CancellationToken cancellationToken = default)
    {
        try
        {
            action.Invoke(_context, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw;
        }
        finally
        {
            _context.ChangeTracker.Clear();
            await _context.Database.CloseConnectionAsync();
        }
    }

    internal async Task<TEntity> DoQueryAsync<TEntity>(Func<TContext, CancellationToken, Task<TEntity>> func,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await func.Invoke(_context, cancellationToken);
            return result;
        }
        finally
        {
            _context.ChangeTracker.Clear();
            await _context.Database.CloseConnectionAsync();
        }
    }
}