
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product
    {


        [Key]
        public int ProductId { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public int CategoryId { get; set; }

        [Display(Name = "نام کالا")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]
        public string Name { get; set; }


        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public int Price { get; set; }


        public string ImageName { get; set; }

        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد")]
        [Display(Name = "")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string Description { get; set; }


        public int? SalesNumber { get; set; }

        public Category Category { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
