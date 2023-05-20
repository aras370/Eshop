using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Products
{
    public class DeleteModel : PageModel
    {

        IProductService _productService;

        public DeleteModel(IProductService productService)
        {
            _productService = productService;
        }

        
        public Product Product { get; set; }


        public void OnGet(int productId)
        {
            Product=_productService.GetProductById(productId);
        }

        public IActionResult OnPost(int productId)
        {
            _productService.DeleteProduct(productId);

            return RedirectToPage("Index");
        }

    }
}
