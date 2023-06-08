﻿using BookApp.DataTransferObjects.Responses;
using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Repositories
{
	public interface IBookRepository : IRepository<Book>
	{
		Task<IList<BookListResponse>> GetBookWithInclude();

		IList<BookListResponse> GetBooksWithCategory(int id);
		
	}
}
