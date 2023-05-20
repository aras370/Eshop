using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        IUserService _userservice;

        public IndexModel(IUserService userservice)
        {
            _userservice = userservice;
        }


        [BindProperty]
        public UsersForAdminViewModel Users { get; set; }


        public  void OnGet(int pageId = 1, string parametr="")
        {
            Users = _userservice.GetUsersForAdmin(pageId,parametr);
        }
    }
}
