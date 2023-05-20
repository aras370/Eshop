using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AddProductViewModel
    {

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


        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد")]
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string Description { get; set; }


        [Display(Name = "عکس")]
        public IFormFile? Image { get; set; }

    }

    public class ShowProductsForAdminViewModel
    {

        public int ProductId { get; set; }
      
        public string CategoryName { get; set; }

       
        public string Name { get; set; }

        public string ImageName { get; set; }

        public int Price { get; set; }


    }

    public class EditProductViewModel
    {

        public int ProductId { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public int CategoryId { get; set; }

        [Display(Name = "نام کالا")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]
        public string Name { get; set; }

        public string ImageName { get; set; }


        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public int Price { get; set; }


        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد")]
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        public string Description { get; set; }


        [Display(Name = "عکس")]
        public IFormFile? Image { get; set; }

    }
}
