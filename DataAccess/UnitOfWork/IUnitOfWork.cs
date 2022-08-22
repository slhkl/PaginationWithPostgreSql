using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
