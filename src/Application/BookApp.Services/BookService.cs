using AutoMapper;
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
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task CreateBookAsync(CreateBookRequest createBookRequest)
        {
            var book = _mapper.Map<Book>(createBookRequest);
            await _bookRepository.CreateAsync(book);
        }

        public IEnumerable<BookListResponse> GetBookList()
        {
            var books = _bookRepository.GetBookWithInclude();
            return books;
        }
    }
}
