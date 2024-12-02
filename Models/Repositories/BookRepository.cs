using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories {
    public class BookRepository : GenericRepository<Book> {
        public BookRepository(MyDBContext context) : base(context) {
        }

        public async Task<SearchResult<Book>> SearchBooksAsync(string categoryName, string bookName, DateTime? publicationDate, string authorName,
            int from, int num) {
            // Applica i filtri in base ai criteri specificati
            var query = _context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(categoryName)) {
                query = query.Where(book => book.BookCategories.Any(lc => lc.Category.Name.ToLower().Contains(categoryName.ToLower())));
            }
            if (!string.IsNullOrEmpty(bookName)) {
                query = query.Where(c => c.Title.ToLower().Contains(bookName.ToLower()));
            }

            if (publicationDate.HasValue && publicationDate.Value != DateTime.MinValue) {
                query = query.Where(book => book.Publication_Date.Date == publicationDate.Value.Date);
            }

            if (!string.IsNullOrEmpty(authorName)) {
                query = query.Where(b => b.Author.ToLower().Contains(authorName.ToLower()));
            }
            var totalNum = await query.CountAsync();
            var result = await query.Skip(from).Take(num).ToListAsync();
            return new SearchResult<Book>(result, totalNum);
        }

        public async Task<SearchResult<Book>> GetBooks(int from, int num) {
            var query = _context.Books.AsQueryable();
            var totalNum = await query.CountAsync();
            var result = await query.Skip(from).Take(num).ToListAsync();
            return new SearchResult<Book>(result, totalNum);
        }
    }
}
