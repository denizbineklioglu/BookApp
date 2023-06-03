using BookApp.Entities;
using BookApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (category != null)
            {
                await _categoryService.CreateCategoryAsync(category);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
