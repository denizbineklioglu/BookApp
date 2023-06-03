using BookApp.DataTransferObjects.Requests;
using BookApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Mvc.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePublisher()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher(CreatePublisherRequest model)
        {
            if (ModelState.IsValid)
            {
                await _publisherService.CreatePublisherAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
