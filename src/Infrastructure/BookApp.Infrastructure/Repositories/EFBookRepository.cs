using BookApp.Entities;
using BookApp.Infrastructure.Context;
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

		public IList<Book> GetAllWithFilter(Expression<Func<Book, bool>> filter)
		{
			return _bookDbContext.Books.Where(filter).ToList();
		}

		public Book? GetById(int id)
		{
			return _bookDbContext.Books.SingleOrDefault(b => b.BookID == id);
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
