using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Users
{
    [PermissionChecker(2)]
    public class DeleteModel : PageModel
    {
        IUserService _userService;

        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]


        public User User { get; set; }



        public void OnGet(int id)
        {
            User = _userService.GetUserByUserId(id);
        }

        public IActionResult OnPost(int userid)
        {

            _userService.deleteUser(userid);

            return RedirectToPage("Index");
        }

    }
}
