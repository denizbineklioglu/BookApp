using Microsoft.AspNetCore.Mvc;

namespace BookApp.Mvc.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
