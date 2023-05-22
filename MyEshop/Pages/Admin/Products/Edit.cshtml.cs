using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyEshop.Pages.Admin.Products
{
    [PermissionChecker(6)]

    public class EditModel : PageModel
    {

        IProductService _productService;
        ICategoryService _categoryService;

        public EditModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public EditProductViewModel Product { get; set; }

        public void OnGet(int productId)
        {
            Product = _productService.GetProductForEdit(productId);
            var categories = _categoryService.GetCategories();
            ViewData["Category"] = new SelectList(categories, "CategoryId", "Name",Product.CategoryId);
        }



        public IActionResult OnPost()
        {
            _productService.EditProduct(Product);

            return RedirectToPage("Index");
        }
    }
}
