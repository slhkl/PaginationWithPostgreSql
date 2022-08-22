using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> condiction);
        void Add(T entitiy);
        void Update(T entity);
        void Delete(T entity);
    }
}
