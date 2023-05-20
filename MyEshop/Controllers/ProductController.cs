using Core;
using Microsoft.AspNetCore.Mvc;

namespace MyEshop.Controllers
{
    public class ProductController : Controller
    {

        IProductService _productService;

        ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult ShowProductInCategory(int categoryId)
        {
            var category=_categoryService.GetCategoryById(categoryId);
            ViewBag.categoryname=category.Name;
            var products=_productService.ShowProductsInCategory(categoryId);
            return View(products);
        }

        public IActionResult ShowProduct(int productId)
        {
            var product=_productService.GetProductById(productId);
            return View(product);
        }
    }
}
