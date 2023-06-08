using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Repositories
{
	public interface ICategoryRepository : IRepository<Category>
	{
		IEnumerable<Category> GetCategoryForComponent();
	}
}
