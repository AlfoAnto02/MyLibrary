using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services {
    public interface IBookCategoryService : GeneralService<BookCategory> {
        Task AddBookCategoryRelationAsync(Book book, IEnumerable<int> categoryIds);
        Task RemoveBookCategoryRelationAsync(Book book);
    }
}
