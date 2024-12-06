using Application.Abstractions.Services;
using Application.Exceptions;
using Application.Models.Request;
using Models.Entities;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services {
    public class BookService : IBookService {

        public readonly BookRepository _bookRepository;
        public readonly IBookCategoryService _bookCategoryService;

        public BookService(BookRepository bookRepository, IBookCategoryService bookCategoryService) {
            this._bookRepository = bookRepository;
            this._bookCategoryService = bookCategoryService;
        }

        public async Task AddAsync(Book entity) {
            _bookRepository.Add(entity);
            await _bookRepository.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id) {
            var book = await GetAsync(id);
            _bookRepository.Delete(book);
            await _bookCategoryService.RemoveBookCategoryRelationAsync(book);
            await _bookRepository.SaveChangesAsync();
        }

        public async Task<Book> GetAsync(int id) {
            var book = await _bookRepository.GetAsync(id);
            if (book == null) {
                throw new WrongIdException(id);
            }
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllAsync() {
            return await _bookRepository.GetAllAsync();
        }
        public async Task<SearchResult<Book>> GetByFilterAsync(SearchRequest filter) {
            var result = await _bookRepository.SearchBooksAsync(filter.CategoryName, filter.BookName,filter.Author);
            return result;
        }

        public async Task<Book> UpdateBookAsync(int bookId, Book book, List<int> categoryIds) {
            var bookToUpdate = await GetAsync(bookId);
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Publication_Date = book.Publication_Date;
            bookToUpdate.Publisher = book.Publisher;
            await _bookCategoryService.RemoveBookCategoryRelationAsync(bookToUpdate);
            await _bookCategoryService.AddBookCategoryRelationAsync(bookToUpdate, categoryIds);
            _bookRepository.Update(bookToUpdate);
            await _bookRepository.SaveChangesAsync();
            return bookToUpdate;
        }

        public async Task<SearchResult<Book>> PageBooks(PaginationRequest paginationRequest) {
            var from = paginationRequest.PageNumber * paginationRequest.PageSize;
            var num = paginationRequest.PageSize;
            return await _bookRepository.GetBooks(from, num);
        }
    }
}
