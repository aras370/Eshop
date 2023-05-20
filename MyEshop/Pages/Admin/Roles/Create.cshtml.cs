using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Roles
{
    public class CreateModel : PageModel
    {

        IRoleService _roleService;

        public CreateModel(IRoleService roleService)
        {
            _roleService = roleService;
        }


        public void OnGet()
        {
            ViewData["Permissions"] = _roleService.GetAllPermissions();
        }


        [BindProperty]
        public Role Role { get; set; }



        public IActionResult OnPost(List<int> SelectedPermission)
        {

            _roleService.AddRole(Role);

            _roleService.AddPermissionToRole(Role.RoleId, SelectedPermission);

            return RedirectToPage("Index");

        }
    }
}
