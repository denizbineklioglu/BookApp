using BookApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Mvc.ViewComponents
{
    public class CategoryMenuComponent :ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryMenuComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var categories =  _categoryService.GetCategoryForComponent();
            return View(categories);    
        }
    }
}
