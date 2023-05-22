using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Categories
{
    [PermissionChecker(12)]

    public class EditModel : PageModel
    {

        ICategoryService _categoryService;

        public EditModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [BindProperty]
        public Category Category { get; set; }

        public void OnGet(int id)
        {
            Category=_categoryService.GetCategoryById(id);
        }

        public IActionResult OnPost()
        {
            _categoryService.EditCategory(Category);

            return RedirectToPage("Index");
        }
    }
}
