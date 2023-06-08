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
	public class EFWriterRepository : IWriterRepository
	{
		private readonly BookDbContext _bookDbContext;

		public EFWriterRepository(BookDbContext bookDbContext)
		{
			_bookDbContext = bookDbContext;
		}

		public async Task CreateAsync(Writer entity)
		{
			await _bookDbContext.Writers.AddAsync(entity);
			await _bookDbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var writer = await _bookDbContext.Writers.FindAsync(id);
			_bookDbContext.Writers.Remove(writer);
			await _bookDbContext.SaveChangesAsync();
		}

        public IList<Writer> GetAll()
        {
            return _bookDbContext.Writers.ToList();
        }

        public async Task<IList<Writer>> GetAllAsync()
		{
			return await _bookDbContext.Writers.ToListAsync();
		}

		public async Task<IList<Writer>> GetAllWithFilterAsync(Expression<Func<Writer, bool>> filter)
		{
			return await _bookDbContext.Writers.Where(filter).ToListAsync();
		}

		public async Task<Writer?> GetByIdAsync(int id)
		{
			return await _bookDbContext.Writers.SingleOrDefaultAsync(c => c.WriterID == id);
		}

		public async Task UpdateAsync(Writer entity)
		{
			_bookDbContext.Writers.Update(entity);
			await _bookDbContext.SaveChangesAsync();
		}
	}
}
