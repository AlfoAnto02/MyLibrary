using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs {
    public class BookDTO {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime Publication_Date { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public List<String> Categories { get; set; }

        public BookDTO(Book book) {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            Publication_Date = book.Publication_Date;
            Publisher = book.Publisher;
            Categories = book.BookCategories
                .Where(bc => bc.BookId == book.Id)
                .Select(bc => bc.Category.Name)
                .ToList();
        }
    }
}
