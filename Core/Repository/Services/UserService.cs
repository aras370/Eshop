using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace Core
{
    public class UserService : IUserService
    {
        MyEshopContext _context;

        public UserService(MyEshopContext context)
        {
            _context = context;
        }

        public bool ActiveAccount(string activeCode)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
            if (user == null || user.IsActive)
            {
                return false;
            }

            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUnique();
            _context.SaveChanges();
            return true;
        }

        public int AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }


        public void EditProfile(EditUserPanelViewModel user)
        {
            if (user.UserAvatar != null)
            {
                string imagePath = "";
                if (user.AvatarName != "Defaulte.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.AvatarName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }
                user.AvatarName = NameGenerator.GenerateUnique() + Path.GetExtension(user.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UserAvatar.CopyTo(stream);
                }
            }


            var updateuser = GetUserByUserId(user.UserId);
            updateuser.AvatarName = user.AvatarName;
            updateuser.Email = user.Email;
            UpdateUser(updateuser);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }


        public User GetUserByUserId(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User GetUserByUserName(string userName)
        {
            return _context.Users.Where(u => u.Name == userName).SingleOrDefault();
        }

        public EditUserPanelViewModel GetUserForEditByUser(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId).Select(u => new EditUserPanelViewModel
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                AvatarName = u.AvatarName,
            }).SingleOrDefault();
        }

        public UserPanelViewModel GetUserForUserPanel(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId).Select(u => new UserPanelViewModel()
            {
                UserId = u.UserId,
                Email = u.Email,
                Name = u.Name,
                AvatarName = u.AvatarName,
                RegisterDate = u.RegisterDate
            }).SingleOrDefault();
        }

        public bool IsExistUser(string name, string email)
        {
            return _context.Users.Any(u => u.Name == name || u.Email == email);
        }

        public User Login(string userName, string password)
        {
            var name = FixText.FixEmail(userName);
            var password1 = HashPassword.EncodePasswordMd5(password);
            return _context.Users.SingleOrDefault(u => u.Name == name && u.Password == password1);
        }

        public void ChangePassword(string userName, string password)
        {
            var user = GetUserByUserName(userName);
            var hashpassword = HashPassword.EncodePasswordMd5(password);
            user.Password = hashpassword;
            _context.SaveChanges();
        }


        public UsersForAdminViewModel  GetUsersForAdmin(int pageId = 1, string parametr = "")
        {
            IQueryable<User> users = _context.Users;

            if (!string.IsNullOrEmpty(parametr))
            {
                users = _context.Users.Where(u => u.Name.Contains(parametr) || u.Email.Contains(parametr));
            }


            int take = 2;

            int skip = (pageId - 1) * take;

            UsersForAdminViewModel list = new UsersForAdminViewModel();

            list.Users = users.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            list.PageCount = users.Count() / take;
            list.CurrentPage = pageId;
            return  list;
        }

        public void DeleteUser(string userName)
        {
           var user=GetUserByUserName(userName);

            user.IsDelete= true;

            _context.SaveChanges();
        }

        public EditUserByAdminViewModel GetUserByAdminForEdit(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId).Select(u => new EditUserByAdminViewModel
            {
                AvatarName = u.AvatarName,
                Email = u.Email,
                Name = u.Name,
                UserRoles = u.UserRoles.Select(r => r.RoleId).ToList()
            }).SingleOrDefault();

            
          
        }

        public int AddUserByAdminViewModel(AddUserByAdminViewModel newUser)
        {
            User user = new User();

            user.ActiveCode = NameGenerator.GenerateUnique();
            if (newUser.UserAvatar != null)
            {
                user.AvatarName = NameGenerator.GenerateUnique() + Path.GetExtension(newUser.UserAvatar.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    newUser.UserAvatar.CopyTo(stream);
                }
            }
            else
            {
                user.AvatarName = "Defaulte.jpg";
            }
            user.IsActive = true;
            user.IsDelete = false;
            user.RegisterDate = DateTime.Now;
            user.Email = newUser.Email;
            user.Name = newUser.Name;
            user.Password = HashPassword.EncodePasswordMd5(newUser.Password);

            AddUser(user);
            return user.UserId;
        }

        public int EditUserByAdmin(EditUserByAdminViewModel user)
        {
            var olduser = GetUserByUserName(user.Name);

            olduser.Email= user.Email;
            olduser.Name = user.Name;
            if (!string.IsNullOrEmpty(user.Password))
            {
                olduser.Password = HashPassword.EncodePasswordMd5(user.Password);
            }

            if (user.UserAvatar!=null && user.UserAvatar.FileName!= "Defaulte.jpg")
            {
                string deletepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", olduser.AvatarName);
                if (File.Exists(deletepath))
                {
                    File.Delete(deletepath);
                }

                olduser.AvatarName = NameGenerator.GenerateUnique() + Path.GetExtension(user.UserAvatar.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", olduser.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UserAvatar.CopyTo(stream);
                }
            }

            _context.Update(olduser);
            _context.SaveChanges();
            return olduser.UserId;
        }

        public void EditUserRolesByAdmin(int userId, List<int> selectedRoles)
        {
            throw new NotImplementedException();
        }

        public void deleteUser(int userId)
        {
            var user = GetUserByUserId(userId);
            user.IsDelete = true;
            _context.SaveChanges();
        }
    }
}
