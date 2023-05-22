using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Roles
{
    [PermissionChecker(10)]

    public class DeleteModel : PageModel
    {

        IRoleService _roleService;


        public DeleteModel(IRoleService roleService)
        {
            _roleService= roleService;  
        }

        [BindProperty]
        public Role  Role { get; set; }

        public void OnGet(int roleId)
        {
            Role=_roleService.GetRole(roleId);
        }

        public IActionResult OnPost()
        {
            _roleService.DeleteRole(Role);

            return RedirectToPage("Index");
        }
    }
}
