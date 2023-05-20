using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace Core
{
    public interface IUserService
    {
        bool IsExistUser(string name, string email);

        int AddUser(User user);

        bool ActiveAccount(string activeCode);

        User Login(string userName, string password);

        User GetUserByEmail(string email);

        User GetUserByActiveCode(string activeCode);

        void UpdateUser(User user);

        User GetUserByUserId(int userId);

        User GetUserByUserName(string userName);

        UsersForAdminViewModel GetUsersForAdmin(int pageId = 1, string parametr = "");

        void DeleteUser(string userName);

        int AddUserByAdminViewModel(AddUserByAdminViewModel user);

        EditUserByAdminViewModel GetUserByAdminForEdit(int userId);

        int EditUserByAdmin(EditUserByAdminViewModel user);

        void EditUserRolesByAdmin(int userId, List<int> selectedRoles);

        void deleteUser(int userId);

        #region UserPanel

        UserPanelViewModel GetUserForUserPanel(int userId);

        EditUserPanelViewModel GetUserForEditByUser(int userId);

        public void EditProfile(EditUserPanelViewModel user);

        void ChangePassword(string userName, string password);

        #endregion
    }
}
