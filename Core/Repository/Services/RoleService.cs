using DataLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class RoleService : IRoleService
    {

        MyEshopContext _context;

        public RoleService(MyEshopContext context)
        {
            _context = context;
        }



        public void AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void AddRoleToUser(List<int> roleId, int userId)
        {
            foreach (var rolid in roleId)
            {
                _context.UserRoles.Add(new UserRoles
                {
                    RoleId = rolid,
                    UserId = userId
                });

            }
            _context.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            _context.Remove(role);
            _context.SaveChanges();
        }

        public void EditUserRoles(List<int> roleId, int userId)
        {
            _context.UserRoles.Where(r => r.UserId == userId).ToList().ForEach(r => _context.UserRoles.Remove(r));
            AddRoleToUser(roleId, userId);
        }

        public List<Permission> GetAllPermissions()
        {
            return _context.Permissions.ToList();
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRole(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public void Update(Role role)
        {

            _context.Update(role);
            _context.SaveChanges();
        }


        public void AddPermissionToRole(int roleId, List<int> SelectedPermissions)
        {
            foreach (var item in SelectedPermissions)
            {
                RolePermissions rolePermissions = new RolePermissions()
                {
                    RoleId = roleId,
                    PermissionId = item
                };
                _context.Add(rolePermissions);
            }
            _context.SaveChanges();
        }

        public List<RolePermissions> GetSelectedPermissions(int roleId)
        {
            return _context.RolePermissions.Where(rp => rp.RoleId == roleId).ToList();
        }

        public void UpdateRolePermissions(int roleId, List<int> permissions)

        {
            _context.RolePermissions.Where(p => p.RoleId == roleId).ToList().ForEach(p => _context.RolePermissions.Remove(p));
            AddPermissionToRole(roleId, permissions);

        }

        public bool CheckUserPermission(int permissionId, string userName)

        {

            var userId = _context.Users.Single(u => u.Name == userName).UserId;

            List<int> userroles = _context.UserRoles.Where(ur => ur.UserId == userId).Select
                (ur => ur.RoleId).ToList();

            if (!userroles.Any())
            {
                return false;
            }

            List<int> rolepermissions=_context.RolePermissions.Where(rp=>rp.PermissionId==permissionId).
                Select(rp=>rp.RoleId).ToList();

          return  rolepermissions.Any(rl=> userroles.Contains(rl));


        }
    }
}
