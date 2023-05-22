using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Categories
{
    [PermissionChecker(11)]

    public class CreateModel : PageModel
    {
        ICategoryService _categoryService;

        public CreateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public Category Category { get; set; }

        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {
           
            _categoryService.AddCategory(Category);
            return RedirectToPage("Index");
        }
    }
}
