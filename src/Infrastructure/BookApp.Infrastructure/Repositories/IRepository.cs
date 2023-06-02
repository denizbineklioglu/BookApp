﻿using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Repositories
{
	public interface IRepository<T> where T : class , IEntity, new()
	{
		Task CreateAsync(T entity);
		Task DeleteAsync(int id);
		Task UpdateAsync(T entity);

		T? GetById(int id);
		Task<T?> GetByIdAsync(int id);

		IList<T> GetAll();
		Task<IList<T>> GetAllAsync();

		IList<T> GetAllWithFilter(Expression<Func<T, bool>> filter);
	}
}