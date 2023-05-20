using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IProductService
    {
        
        List<ShowProductsForAdminViewModel> GetAllProducts();

        void AddProduct(AddProductViewModel product);

        EditProductViewModel GetProductForEdit(int productId);

        void EditProduct(EditProductViewModel product);

        Product GetProductById(int productId);

        void DeleteProduct(int productId);

        List<Product> ShowProductsInCategory(int categoryId);

        List<Product> MostPopularProducts();


    }
}
