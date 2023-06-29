using Core;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Products
{
    [PermissionChecker(15)]
    public class IndexModel : PageModel
    {

       IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService=productService;
        }

        [BindProperty]
        public List<ShowProductsForAdminViewModel> Products { get; set; }

        public void OnGet()
        {
            Products=_productService.GetAllProducts();
        }
    }
}
