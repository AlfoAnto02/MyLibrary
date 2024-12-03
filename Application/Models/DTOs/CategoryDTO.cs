using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs {
    public class CategoryDTO {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public CategoryDTO(Category category) {
            Id = category.Id;
            Name = category.Name;
        }
    }
}
