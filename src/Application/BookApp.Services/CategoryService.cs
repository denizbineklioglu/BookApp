using AutoMapper;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _categoryRepository.CreateAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public IEnumerable<CategoryDisplayResponse> GetCategoriesForList()
        {
            var items =  _categoryRepository.GetAll();
            var response = _mapper.Map<IEnumerable<CategoryDisplayResponse>>(items);
            return response;
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public IEnumerable<Category> GetCategoryForComponent()
        {
            return _categoryRepository.GetCategoryForComponent();
        }

        public async Task UpdateCategotyAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
