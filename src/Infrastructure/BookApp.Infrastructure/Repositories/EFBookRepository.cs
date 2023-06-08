using BookApp.DataTransferObjects.Responses;
using BookApp.Entities;
using BookApp.Infrastructure.Context;
using BookApp.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Repositories
{
	public class EFBookRepository : IBookRepository
	{
		private readonly BookDbContext _bookDbContext;

		public EFBookRepository(BookDbContext bookDbContext)
		{
			_bookDbContext = bookDbContext;
		}

		public async Task CreateAsync(Book entity)
		{
			await _bookDbContext.Books.AddAsync(entity);
			await _bookDbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var book = await _bookDbContext.Books.FindAsync(id);
			_bookDbContext.Books.Remove(book);
			await _bookDbContext.SaveChangesAsync();
		}

        public IList<Book> GetAll()
        {
           return _bookDbContext.Books.ToList();
        }

        public async Task<IList<Book>> GetAllAsync()
		{
			return await _bookDbContext.Books.ToListAsync();
		}

		public async Task<IList<Book>> GetAllWithFilterAsync(Expression<Func<Book, bool>> filter)
		{
			return await _bookDbContext.Books.Where(filter).ToListAsync();
		}

        public IList<BookListResponse> GetBooksWithCategory(int id)
        {
			var books = _bookDbContext.Books.Where(b => b.CategoryID == id);
			var result = books.Select(b => new BookListResponse
			{
				BookID = b.BookID,
				Name = b.Name,
				Price = b.Price,
				ImageUrl = b.ImageUrl,
				CategoryName = b.Category.Name,
				PublisherName = b.Publisher.Name,
				WriterName = b.Writer.FirstName + " " + b.Writer.LastName
			}).ToList();
			return result;
        }

        public  async Task<IList<BookListResponse>> GetBookWithInclude()
        {
            var books = await GetAllAsync();
            var result = await _bookDbContext.Books.Select(b => new BookListResponse
            {
				BookID = b.BookID,
                Name = b.Name,
                Price = b.Price,
                ImageUrl = b.ImageUrl,
                CategoryName = b.Category.Name,
                PublisherName = b.Publisher.Name,
                WriterName = b.Writer.FirstName + " " + b.Writer.LastName
            }).ToListAsync();
            return result;
        }

		public async Task<Book?> GetByIdAsync(int id)
		{
			return await _bookDbContext.Books.SingleOrDefaultAsync(b => b.BookID == id);
		}

		public async Task UpdateAsync(Book entity)
		{
			_bookDbContext.Books.Update(entity);
			await _bookDbContext.SaveChangesAsync();
		}
    }
}
