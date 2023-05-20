using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Users
{
    public class CreateModel : PageModel
    {

        IUserService _userservice;
        IRoleService _roleService;

        public CreateModel(IUserService userservice, IRoleService roleService)
        {
            _userservice = userservice;
            _roleService = roleService;
        }

        [BindProperty]
        public AddUserByAdminViewModel User { get; set; }

        public void OnGet()
        {
            ViewData["Roles"] = _roleService.GetAllRoles();
        }


        public IActionResult OnPost(List<int> SelectedRoles)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userid = _userservice.AddUserByAdminViewModel(User);
            _roleService.AddRoleToUser( SelectedRoles,userid);
            //ViewData["IsSuccess"] = true;
            return RedirectToPage("Index");
        }

    }
}
