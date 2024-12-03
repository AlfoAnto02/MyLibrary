using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Application.Abstractions.Services {
    public interface ICategoryService : GeneralService<Category> {
        Task<Category> DeleteCategoryAsync(int id);
    }
}
