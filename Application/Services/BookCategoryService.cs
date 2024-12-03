using Application.Abstractions.Services;
using Models.Entities;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services {
    public class BookCategoryService : IBookCategoryService {
        public readonly ICategoryService _categoryService;
        public readonly BookCategoryRepository bookCategoryRepository;
        public BookCategoryService(ICategoryService _categoryService,
            BookCategoryRepository bookCategoryRepository) {
            this._categoryService = _categoryService;
            this.bookCategoryRepository = bookCategoryRepository;
        }

        public async Task AddBookCategoryRelationAsync(Book book, IEnumerable<int> categoryIds) {
            foreach (var categoryId in categoryIds) {
                var category = await _categoryService.GetAsync(categoryId);
                var bookCategory = new BookCategory {
                    Book = book,
                    BookId = book.Id,
                    CategoryId = categoryId,
                    Category = category
                };
                book.BookCategories.Add(bookCategory);
                category.BookCategories.Add(bookCategory);
            }
        }

        public async Task RemoveBookCategoryRelationAsync(Book book) {
            var bookCategoriesToRemove = await bookCategoryRepository.GetByBookIdAsync(book.Id);
            foreach (var bookCategory in bookCategoriesToRemove) {
                bookCategoryRepository.Delete(bookCategory);
            }
            await bookCategoryRepository.SaveChangesAsync();
        }

        public async Task AddAsync(BookCategory entity) {
            bookCategoryRepository.Add(entity);
            await bookCategoryRepository.SaveChangesAsync();
        }

        public async Task<BookCategory> GetAsync(int id) {
            return await bookCategoryRepository.GetAsync(id);
        }

        public async Task<IEnumerable<BookCategory>> GetAllAsync() {
            return await bookCategoryRepository.GetAllAsync();
        }
    }
}
