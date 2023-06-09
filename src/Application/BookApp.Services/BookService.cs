﻿using AutoMapper;
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

        public async Task DeleteBook(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<BookDisplayResponse> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookDisplayResponse>(book);
        }

        public  BookDisplayResponse GetBookForBasket(int id)
        {
            var book = _bookRepository.GetById(id);
            return _mapper.Map<BookDisplayResponse>(book);
        }

        public async Task<IEnumerable<BookDisplayResponse>> GetBookList()
        {
            var books = await _bookRepository.GetBookWithInclude();
            return books;
        }

        public IEnumerable<BookDisplayResponse> GetBooksWithCategories(int id)
        {
            return _bookRepository.GetBooksWithCategory(id);
        }

        public async Task<UpdateBookRequest> TGetByIdUpdate(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            var result = _mapper.Map<UpdateBookRequest>(book);
            return result;
        }

        public async Task UpdateBookAsync(UpdateBookRequest updateBookRequest)
        {
            var book = _mapper.Map<Book>(updateBookRequest);
            await _bookRepository.UpdateAsync(book);
        }
    }
}
