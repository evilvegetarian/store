using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly BookSevice bookSevice;

        public SearchController(BookSevice bookSevice)
        {
            this.bookSevice = bookSevice;
        }

        public IActionResult Index(string query)
        {
            var books = bookSevice.GetAllbyQuery(query);
            return View(books);
        }
    }
}
