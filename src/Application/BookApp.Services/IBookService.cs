using BookApp.DataTransferObjects.Requests;
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
	public interface IBookService 
	{
		Task CreateBookAsync(CreateBookRequest createBookRequest);
		IEnumerable<BookListResponse> GetBookList();
		Task DeleteBook(int id);
		Task UpdateBookAsync(UpdateBookRequest updateBookRequest);
		UpdateBookRequest TGetByIdUpdate(int id);

        IEnumerable<BookListResponse> GetBooksWithCategories(int id);

        BookListResponse GetBook(int id);
    }
}
