using Core;
using DataLayer;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Categories
{
    [PermissionChecker(16)]
    public class IndexModel : PageModel
    {
        ICategoryService _categoryService;


        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]

        public List<Category> Categories { get; set; }



        public void OnGet()
        {
            Categories = _categoryService.GetCategories();
        }
    }
}
