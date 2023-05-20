
using DataLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface ICategoryService
    {
        List<Category> GetCategories();

        Category GetCategoryById(int categoryId);

        void DeleteCategory(Category category);

        void EditCategory(Category category);

        void AddCategory(Category category);

        List<SelectListItem> GetCategoryForManageProduct();
    }
}
