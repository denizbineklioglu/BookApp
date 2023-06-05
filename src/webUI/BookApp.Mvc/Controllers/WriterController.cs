using BookApp.DataTransferObjects.Requests;
using BookApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Mvc.Controllers
{
	[Authorize(Roles = "Admin")]
	public class WriterController : Controller
	{
		private readonly IWriterService _writerService;

		public WriterController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		public IActionResult Index()
		{
			var writers = _writerService.GetAll();
			return View(writers);
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

		public async Task<IActionResult> DeleteWriter(int id)
		{
			await _writerService.DeleteWriterAsync(id);
			return RedirectToAction("Index");
		}

		public IActionResult UpdateWriter(int id)
		{
			var writer = _writerService.GetByIdUpdate(id);
			return View(writer);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateWriter(UpdateWriterRequest model)
		{
			if (ModelState.IsValid)
			{
				await _writerService.UpdateWriterAsync(model);
				return RedirectToAction("Index");	
			}
			return View();
		}
	}
}
