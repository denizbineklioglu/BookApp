﻿using BookApp.DataTransferObjects.Requests;
using BookApp.Entities;
using BookApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookApp.Mvc.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IWriterService _writerService;
        private readonly IPublisherService _publisherService;

        public BookController(IBookService bookService, ICategoryService categoryService, IWriterService writerService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _writerService = writerService;
            _publisherService = publisherService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetBookList();
            return View(books);
        }

        public IActionResult CreateBook()
        {
            ViewBag.categories = getCategoriesforSelectList();
            ViewBag.writers = getWritersforSelectList();
            ViewBag.publishers = getPublishersforSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookRequest model)
        {
            if (ModelState.IsValid)
            {
                await _bookService.CreateBookAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditBook(int id)
        {
            ViewBag.categories = getCategoriesforSelectList();
            ViewBag.writers = getWritersforSelectList();
            ViewBag.publishers = getPublishersforSelectList();
            var book = _bookService.TGetByIdUpdate(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(UpdateBookRequest model)
        {
            if (ModelState.IsValid)
            {
                await _bookService.UpdateBookAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        private IEnumerable<SelectListItem> getCategoriesforSelectList()
        {
            var categories = _categoryService.GetCategoriesForList().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.CategoryID.ToString()
            }).ToList();
            return categories;
        }

        private IEnumerable<SelectListItem> getWritersforSelectList()
        {
            var writers = _writerService.GetWritersForList().Select(w => new SelectListItem
            {
                Text = w.FirstName + " " +  w.LastName,
                Value = w.WriterID.ToString()
            }).ToList();
            return writers;
        }

        private IEnumerable<SelectListItem> getPublishersforSelectList()
        {
            var publishers = _publisherService.GetPublishersForList().Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.PublisherID.ToString()
            }).ToList();
            return publishers;
        }
    }
}
