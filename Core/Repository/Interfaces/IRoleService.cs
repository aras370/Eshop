using DataLayer;

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IRoleService
    {
        List<Role> GetAllRoles();

        void AddRoleToUser(List<int> roleId, int userId);

        void EditUserRoles(List<int> roleId, int userId);

        void AddRole(Role role);

        Role GetRole(int roleId);

        void Update(Role role);

        void DeleteRole(Role role);

        #region Permissions


        List<Permission> GetAllPermissions();

        void AddPermissionToRole(int roleId, List<int> SelectedPermissions);

        List<RolePermissions> GetSelectedPermissions(int roleId);


        public void UpdateRolePermissions(int roleId, List<int> permissions);


        bool CheckUserPermission(int permissionId, string userName);
     
        #endregion

    }
}
