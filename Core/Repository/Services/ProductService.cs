using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ProductService : IProductService
    {
        MyEshopContext _context;

        public ProductService(MyEshopContext context)
        {
            _context = context;
        }


        public void AddProduct(AddProductViewModel product)
        {


            Product newproduct = new Product();

            newproduct.Name = product.Name;
            newproduct.CategoryId = product.CategoryId;
            newproduct.Description = product.Description;
            newproduct.Price = product.Price;


            if (product.Image == null)
            {
                newproduct.ImageName = "NoPhoto.jpg";
            }

            else
            {
                newproduct.ImageName = NameGenerator.GenerateUnique() + Path.GetExtension(product.Image.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductsImages", newproduct.ImageName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    product.Image.CopyTo(stream);
                }
            }

            _context.Add(newproduct);
            _context.SaveChanges();
        }



        public List<ShowProductsForAdminViewModel> GetAllProducts()
        {
            return _context.Products.Include(p => p.Category).Select(p => new ShowProductsForAdminViewModel
            {
                ProductId = p.ProductId,
                CategoryName = p.Category.Name,
                Name = p.Name,
                Price = p.Price,
                ImageName = p.ImageName,
            }).ToList();


        }


        public EditProductViewModel GetProductForEdit(int productId)
        {

            return _context.Products.Where(p => p.ProductId == productId).Select(p => new EditProductViewModel
            {
                CategoryId = p.CategoryId,
                Description = p.Description,
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                ImageName = p.ImageName
            }).SingleOrDefault();

        }


        public void EditProduct(EditProductViewModel product)
        {
            var oldproduct = _context.Products.Find(product.ProductId);

            oldproduct.Description = product.Description;
            oldproduct.Price = product.Price;
            oldproduct.Name = product.Name;
            oldproduct.CategoryId = product.CategoryId;

            if (product.Image != null)
            {
                if (product.ImageName != "NoPhoto.jpg")
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductsImages", product.ImageName);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }

                oldproduct.ImageName = NameGenerator.GenerateUnique() + Path.GetExtension(product.Image.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductsImages", oldproduct.ImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    product.Image.CopyTo(stream);
                }


            }


            _context.Products.Update(oldproduct);
            _context.SaveChanges();
        }


        public Product GetProductById(int productId)
        {
            return _context.Products.Include(p=>p.Category).SingleOrDefault(p=>p.ProductId==productId);
        }


        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            _context.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> ShowProductsInCategory(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> MostPopularProducts()
        {
            return _context.Products.OrderByDescending(p=>p.SalesNumber).Take(4).ToList();  
        }


        public void AddComment(Comment comment)
        {
            _context.Add(comment);
            _context.SaveChanges();
        }

        public List<Comment> GetComments(int productId)
        {
            return _context.Comments.Include(c=>c.User).OrderByDescending(c=>c.DateTime).Where(c=>c.ProductId==productId).ToList();
        }
    }
}
