using Core;
using Core.Convertors;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyEshop.Controllers
{
    public class ProductController : Controller
    {

        IProductService _productService;

        ICategoryService _categoryService;

        IUserService _userService;


        public ProductController(IProductService productService, ICategoryService categoryService, IUserService userService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userService = userService;
        }

        public IActionResult ShowProductInCategory(int categoryId)
        {
            var category=_categoryService.GetCategoryById(categoryId);
            ViewBag.categoryname=category.Name;
            var products=_productService.ShowProductsInCategory(categoryId);
            return View(products);
        }

        public IActionResult ShowProduct(int id)
        {
            var product=_productService.GetProductById(id);
            ViewBag.comments = _productService.GetComments(id);

            return View(product);
        }

        [Authorize]
        public IActionResult AddComment(string comment,int productId)
        {

            var user = _userService.GetUserByUserName(User.Identity.Name);

            Comment newcomment = new Comment()
            {
                CommentText = comment,
                UserId=user.UserId,
                ProductId=productId,
                DateTime=DateTime.Now              
            };

            _productService.AddComment(newcomment);

            return Redirect("/Product/ShowProduct/" + productId);
        }
    }
}
