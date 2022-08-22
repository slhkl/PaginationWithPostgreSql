using Business.Abstract;
using Data.Entities;
using DataAccess.UnitOfWork;

namespace Business.Concrete
{
    public class BookBusiness : IBusiness<Book>
    {
        public IQueryable<Book> Get()
        {
            IQueryable<Book> Books;
            using (UnitOfWork unit = new UnitOfWork())
            {
                Books = unit.GetRepository<Book>().Get();
            }
            return Books;
        }

        public IQueryable<Book> Get(PaginationParameters parameters)
        {
            IQueryable<Book> Books;
            using (UnitOfWork unit = new UnitOfWork())
            {
                Books = unit.GetRepository<Book>().Get().Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize);
            }
            return Books;
        }

        public int Count()
        {
            int count;
            using (UnitOfWork unit = new UnitOfWork())
            {
                count = unit.GetRepository<Book>().Get().Count();
            }
            return count;
        }

        public void Add()
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                for (int i = 0; i < 10000; i++)
                {
                    unit.GetRepository<Book>().Add(
                        new Book()
                        {
                            Title = "Kitap:" + i,
                            Writer = i + ".Kitap yazarı"
                        });
                }
                unit.SaveChanges();
            }
        }
    }
}
