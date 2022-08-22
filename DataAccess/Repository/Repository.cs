using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }
        public void Add(T entitiy)
        {
            dbSet.Add(entitiy);
        }

        public void Delete(T entity)
        {
            dbSet?.Remove(entity);
        }

        public IQueryable<T> Get()
        {
            return dbSet.AsQueryable();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> condiction)
        {
            return dbSet.Where(condiction);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
