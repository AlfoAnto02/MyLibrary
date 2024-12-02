using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories {
    public class BookCategoryRepository : GenericRepository<BookCategory> {
        public BookCategoryRepository(MyDBContext context) : base(context) {
        }
        public async Task<BookCategory> GetAsync(int bookId, int categoryId) {
            return await _context.BookCategories.FirstOrDefaultAsync(bc => bc.BookId == bookId && bc.CategoryId == categoryId);
        }

        public async Task<List<BookCategory>> GetByBookIdAsync(int id) {
            return await _context.BookCategories.Where(bc => bc.BookId == id).ToListAsync();
        }
    }
}
