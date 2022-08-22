using Data.Entities;

namespace Business.Abstract
{
    public interface IBusiness<T>
    {
        int Count();
        IQueryable<T> Get();
        IQueryable<T> Get(PaginationParameters parameters);
    }
}