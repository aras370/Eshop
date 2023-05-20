using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DataLayer
{
    public class UserPanelViewModel
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string AvatarName { get; set; }

        public DateTime RegisterDate { get; set; }

    }

    public class EditUserPanelViewModel
    {

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string AvatarName { get; set; }

        public IFormFile UserAvatar { get; set; }
    }

    public class ChangePasswordViewModel
    {

        [Display(Name = "کلمه عبور")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Password { get; set; }


        [Display(Name = "تکرار کلمه عبور ")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [Compare("Password", ErrorMessage = "کلمه های عبور وارد شده مطابقت ندارند")]
        public string RePassword { get; set; }
    }
}
