using System.Linq.Expressions;

namespace WebApi.Repository;

public interface IRepository<T>
{
    IQueryable<T> Get();
    Task<T> GetByCondition(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);

}
