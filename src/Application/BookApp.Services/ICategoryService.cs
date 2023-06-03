using BookApp.DataTransferObjects.Responses;
using BookApp.Entities;
using BookApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Services
{
	public interface ICategoryService 
	{
		Task CreateCategoryAsync(Category category);
        IEnumerable<CategoryDisplayResponse> GetCategoriesForList();

		IEnumerable<Category> GetAll();

		Task DeleteCategoryAsync(int id);
		Task UpdateCategotyAsync(Category category);

		Category GetCategoryById(int id);
    }
}
