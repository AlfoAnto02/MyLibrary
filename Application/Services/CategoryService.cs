using Application.Abstractions.Services;
using Application.Exceptions;
using Castle.Core.Internal;
using Models.Entities;
using Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services {
    public class CategoriesService : ICategoryService {

        public readonly CategoryRepository _categoriesRepository;

        public CategoriesService(CategoryRepository categoriesRepository) {
            this._categoriesRepository = categoriesRepository;
        }

        public async Task AddAsync(Category entity) {
            _categoriesRepository.Add(entity);
            await _categoriesRepository.SaveChangesAsync();
        }

        public async Task<Category> DeleteCategoryAsync(int id) {
            var category = await GetAsync(id);

            if (category.BookCategories.IsNullOrEmpty()) {
                _categoriesRepository.Delete(category);
                await _categoriesRepository.SaveChangesAsync();
                return category;
            }

            var message = new StringBuilder();
            foreach (var bookCategory in category.BookCategories) {
                message.Append(bookCategory.Book.Title);
                message.Append(", ");
            }
            message.Length -= 2;
            throw new AssociatedBookException(message.ToString());
        }

        public async Task<Category> GetAsync(int id) {
            var category = await _categoriesRepository.GetAsync(id);
            if (category == null) {
                throw new WrongIdException(id);
            }
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() {
            return await _categoriesRepository.GetAllAsync();
        }
    }
}
