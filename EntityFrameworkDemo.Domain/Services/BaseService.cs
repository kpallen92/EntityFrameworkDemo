using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Domain.Services;

public class BaseService
{
    protected readonly DemoContext Context;

    protected BaseService(DemoContext context)
    {
        Context = context;
    }

    protected virtual async Task CreateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        Context.Add(entity);
        await Context.SaveChangesAsync();
    }

    protected virtual async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
    {
        Context.Remove(entity);
        await Context.SaveChangesAsync();
    }

    protected virtual async Task<TEntity?> GetAsync<TEntity>(int primaryKeyValue) where TEntity : class
    {
        return await Context.FindAsync<TEntity>(primaryKeyValue);
    }
}