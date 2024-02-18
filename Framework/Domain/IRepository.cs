using System.Linq.Expressions;

namespace Framework.Domain;

public interface IRepository<TKey,TEntity> where TEntity : class
{
    TEntity Create(TEntity entity);
    TEntity Get(TKey key);
    TEntity Get(TEntity key);
    bool Exists(Expression<Func<TEntity, bool>> expression);
    List<TEntity> List();
    void SaveChanges();
}