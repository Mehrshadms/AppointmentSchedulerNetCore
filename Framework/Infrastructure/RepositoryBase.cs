using System.Linq.Expressions;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace Framework.Infrastructure;

public class RepositoryBase<TKey,TEntity> : IRepository<TKey,TEntity> where TEntity : class
{
    private readonly DbContext _Context;

    public RepositoryBase(DbContext context)
    {
        _Context = context;
    }

    public void Create(TEntity entity)
    {
        _Context.Add<TEntity>(entity);
    }

    public TEntity Get(TKey key)
    {
        return _Context.Find<TEntity>(key);
    }

    public TEntity Get(TEntity key)
    {
        return _Context.Find<TEntity>(key);
    }

    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return _Context.Set<TEntity>().Any(expression);
    }

    public List<TEntity> List()
    {
        return _Context.Set<TEntity>().ToList();
    }

    public void SaveChanges()
    {
        _Context.SaveChanges();
    }
}