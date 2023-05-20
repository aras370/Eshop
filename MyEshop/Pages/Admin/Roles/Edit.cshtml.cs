using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Roles
{
    public class EditModel : PageModel
    {
        IRoleService _roleService;

        public EditModel(IRoleService roleService)
        {
            _roleService = roleService;
        }


        [BindProperty]

        public Role Role { get; set; }


        public void OnGet(int roleId)
        {
            ViewData["SelectedPermission"] = _roleService.GetSelectedPermissions(roleId);

            ViewData["Permissions"] = _roleService.GetAllPermissions();
            Role = _roleService.GetRole(roleId);
        }


        public IActionResult OnPost(List<int> SelectedPermission)
        {


            _roleService.Update(Role);

            _roleService.UpdateRolePermissions(Role.RoleId, SelectedPermission);

            return RedirectToPage("Index");
        }
    }
}
