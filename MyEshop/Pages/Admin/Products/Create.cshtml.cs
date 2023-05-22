using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyEshop.Pages.Admin.Products
{
    [PermissionChecker(5)]
    public class CreateModel : PageModel
    {
        ICategoryService _categoryService;
        IProductService _productService;

        public CreateModel(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
            
        }

        public void OnGet()
        {
            
        }

        [BindProperty]
        public AddProductViewModel Prouduct { get; set; }



        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _productService.AddProduct(Prouduct);

            return RedirectToPage("Index");
        }

    }
}
