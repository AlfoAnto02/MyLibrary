using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories {
    public class CategoryRepository : GenericRepository<Category> {
        public CategoryRepository(MyDBContext context) : base(context) {
        }

        public async Task<Category> GetByName(string name) {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
