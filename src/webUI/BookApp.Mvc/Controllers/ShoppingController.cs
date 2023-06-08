using BookApp.DataTransferObjects.Responses;
using BookApp.Mvc.Extensions;
using BookApp.Mvc.Models;
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
            var bookCollection = GetBooksFromSession();
            return View(bookCollection);
        }

        public async Task<IActionResult> AddBook(int id)
        {
            BookDisplayResponse book = await _bookService.GetBookForBasket(id);
            var bookItem = new BookItem
            {
                Book = book,
                Quantity = 1
            };
            BookCollection bookCollection = GetBooksFromSession();
            bookCollection.AddNewBook(bookItem);
            saveToSession(bookCollection);
            return Json(new { message = $"{book.Name} Sepete Eklendi" });
        }

        private BookCollection GetBooksFromSession()
        {
            return HttpContext.Session.GetJson<BookCollection>("basket") ?? new BookCollection(); 
        }

        private void saveToSession(BookCollection bookCollection)
        {
            HttpContext.Session.SetJson("basket", bookCollection);
        }

    }
}
