using BookApp.DataTransferObjects.Responses;
using BookApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Mvc.Controllers
{
    public class ShoppingController : Controller
    {

        private readonly IBookService _bookService;

        public ShoppingController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
