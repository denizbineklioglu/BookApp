using BookApp.DataTransferObjects.Requests;
using BookApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
            var publishers = _publisherService.GetAll();
            return View(publishers);
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

        public async Task<IActionResult> DeletePublisher(int id)
        {
            await _publisherService.DeletePublisherAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult UpdatePublisher(int id)
        {
            var publisher = _publisherService.GetByIdUpdate(id);
            return View(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePublisher(UpdatePublisherRequest model)
        {
            if (ModelState.IsValid)
            {
                await _publisherService.UpdatePublisherAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
