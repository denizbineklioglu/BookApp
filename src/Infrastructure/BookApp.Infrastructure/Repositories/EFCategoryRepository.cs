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
	public class EFCategoryRepository : ICategoryRepository
	{
		private readonly BookDbContext _bookDbContext;

		public EFCategoryRepository(BookDbContext bookDbContext)
		{
			_bookDbContext = bookDbContext;
		}

		public async Task CreateAsync(Category entity)
		{
			await _bookDbContext.Categories.AddAsync(entity);
			await _bookDbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var category = await _bookDbContext.Categories.FindAsync(id);
			_bookDbContext.Categories.Remove(category);
			await _bookDbContext.SaveChangesAsync();
		}

        public IList<Category> GetAll()
        {
			return _bookDbContext.Categories.ToList();
        }

        public async Task<IList<Category>> GetAllAsync()
		{
			return await _bookDbContext.Categories.ToListAsync();
		}

		public async Task<IList<Category>> GetAllWithFilterAsync(Expression<Func<Category, bool>> filter)
		{
			return await _bookDbContext.Categories.Where(filter).ToListAsync();
		}

		public async Task<Category?> GetByIdAsync(int id)
		{
			return await _bookDbContext.Categories.SingleOrDefaultAsync(c => c.CategoryID == id);
		}

		public async Task UpdateAsync(Category entity)
		{
			_bookDbContext.Categories.Update(entity);
			await _bookDbContext.SaveChangesAsync();
		}
	}
}
