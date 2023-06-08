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
		Task<IEnumerable<BookDisplayResponse>> GetBookList();
		Task DeleteBook(int id);
		Task UpdateBookAsync(UpdateBookRequest updateBookRequest);
		Task<UpdateBookRequest> TGetByIdUpdate(int id);

        IEnumerable<BookDisplayResponse> GetBooksWithCategories(int id);

        Task<BookDisplayResponse> GetBook(int id);

		BookDisplayResponse GetBookForBasket(int id);
    }
}
