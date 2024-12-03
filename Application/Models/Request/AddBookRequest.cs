using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request {
    public class AddBookRequest {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime Publication_Date { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public List<int> CategoriesIds { get; set; }

        public Book ToEntity() {
            return new Book {
                Title = Title,
                Author = Author,
                Publication_Date = Publication_Date,
                Publisher = Publisher
            };
        }

    }
}
