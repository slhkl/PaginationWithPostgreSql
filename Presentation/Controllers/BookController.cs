using Business;
using Business.Concrete;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class BookController : Controller
    {
        BookBusiness bookBusiness;

        public BookController()
        {
            bookBusiness = new BookBusiness();
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", new PaginationParameters());
        }

        public IActionResult List(PaginationParameters parameters)
        {
            return View(PagedList<Book>.ToPagedList(bookBusiness, parameters));
        }

        public void Add()
        {
            bookBusiness.Add();
        }
    }
}
