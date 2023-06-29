using Core;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyEshop.Pages.Admin.Roles
{
    [PermissionChecker(17)]
    public class IndexModel : PageModel
    {

        IRoleService _roleService;

        public IndexModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public List<Role> Roles { get; set; }

        public void OnGet()
        {
            Roles = _roleService.GetAllRoles();
        }
    }
}
