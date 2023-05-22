using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Categories
{
    [PermissionChecker(13)]

    public class DeleteModel : PageModel
    {
        ICategoryService _categoryService;


        public DeleteModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [BindProperty]

        public Category Category { get; set; }

        public void OnGet(int id)
        {
            Category = _categoryService.GetCategoryById(id);
           
        }


        public IActionResult OnPost()
        {
            _categoryService.DeleteCategory(Category);

            return RedirectToPage("Index");
        }
    }
}
