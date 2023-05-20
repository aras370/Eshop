using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Users
{
    public class EditModel : PageModel
    {
        IUserService _userservice;
        IRoleService _roleService;
        public EditModel(IUserService userservice, IRoleService roleService)
        {
            _userservice = userservice;
            _roleService = roleService;
        }

        [BindProperty]

        public EditUserByAdminViewModel User { get; set; }


        public void OnGet(int id)
        {
            User = _userservice.GetUserByAdminForEdit(id);
            ViewData["Roles"] = _roleService.GetAllRoles();
        }

        public IActionResult OnPost(List<int> selectedRoles)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int userid = _userservice.EditUserByAdmin(User);
            _roleService.EditUserRoles(selectedRoles, userid);

            return RedirectToPage("Index");
        }
    }
}
