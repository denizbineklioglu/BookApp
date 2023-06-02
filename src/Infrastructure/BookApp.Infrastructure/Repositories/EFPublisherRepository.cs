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
	public class EFPublisherRepository : IPublisherRepository
	{
		private readonly BookDbContext _bookDbContext;

		public EFPublisherRepository(BookDbContext bookDbContext)
		{
			_bookDbContext = bookDbContext;
		}

		public async Task CreateAsync(Publisher entity)
		{
			await _bookDbContext.Publishers.AddAsync(entity);
			await _bookDbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var publisher = await _bookDbContext.Publishers.FindAsync(id);
			_bookDbContext.Publishers.Remove(publisher);
			await _bookDbContext.SaveChangesAsync();
		}

		public IList<Publisher> GetAll()
		{
			return _bookDbContext.Publishers.ToList();
		}

		public async Task<IList<Publisher>> GetAllAsync()
		{
			return await _bookDbContext.Publishers.ToListAsync();
		}

		public IList<Publisher> GetAllWithFilter(Expression<Func<Publisher, bool>> filter)
		{
			return _bookDbContext.Publishers.Where(filter).ToList();
		}

		public Publisher? GetById(int id)
		{
			return _bookDbContext.Publishers.SingleOrDefault(p => p.PublisherID == id);
		}

		public async Task<Publisher?> GetByIdAsync(int id)
		{
			return await _bookDbContext.Publishers.SingleOrDefaultAsync(p => p.PublisherID == id);
		}

		public async Task UpdateAsync(Publisher entity)
		{
			_bookDbContext.Publishers.Update(entity);
			await _bookDbContext.SaveChangesAsync();
		}
	}
}
