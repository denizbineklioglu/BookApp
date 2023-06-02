using BookApp.DataTransferObjects.Requests;
using BookApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Mvc.Controllers
{
	public class WriterController : Controller
	{
		private readonly IWriterService _writerService;

		public WriterController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> CreateWriter()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateWriter(CreateWriterRequest model)
		{
			if (ModelState.IsValid)
			{
				await _writerService.CreateWriterAsync(model);
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
