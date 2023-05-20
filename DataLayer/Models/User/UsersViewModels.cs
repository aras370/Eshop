using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UsersForAdminViewModel
    {
        public List<User> Users { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }
    }

    public class AddUserByAdminViewModel
    {
      

        [Display(Name = " نام کاربری")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50)]
        public string Name { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست")]
        public string Email { get; set; }


        [Display(Name = "کلمه عبور")]    
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]

        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Password { get; set; }

       

        public IFormFile? UserAvatar { get; set; }
    }

    public class EditUserByAdminViewModel
    {
        [Display(Name = " نام کاربری")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50)]
        public string Name { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست")]
        public string Email { get; set; }


        [Display(Name = "کلمه عبور")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Password { get; set; }

        public List<int>? UserRoles { get; set; }

        public string AvatarName { get; set; }

        public IFormFile? UserAvatar { get; set; }
    }
}
