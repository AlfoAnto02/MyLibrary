using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request;
using Models.Entities;

namespace Application.Abstractions.Services {
    public interface IBookService : GeneralService<Book> {
        Task DeleteBookAsync(int id);
        Task<Book> UpdateBookAsync(int bookId, Book book, List<int> categoryIds);
        Task<SearchResult<Book>> GetByFilterAsync(SearchRequest property);
        Task<SearchResult<Book>> PageBooks(PaginationRequest property);

    }
}
