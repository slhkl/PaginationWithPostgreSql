using Data.Contexts;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext dbContext;
        public DbContext DbContext
        {
            get
            {
                if (dbContext == null)
                    dbContext = new DataContext();
                return dbContext;
            }
        }
        public Repository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(DbContext);
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
