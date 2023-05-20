using Core;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyEshop.Areas.UserPanel.Controllers
{

    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index(int id)
        {
            var user = _userService.GetUserForUserPanel(id);
            return View(user);
        }

        public IActionResult EditUserPanel(int userId)
        {
            var user = _userService.GetUserForEditByUser(userId);

            return View(user);
        }

        [HttpPost]
        public IActionResult EditUserPanel(EditUserPanelViewModel user)
        {
            _userService.EditProfile(user);

            return Redirect("/UserPanel/Home/Index/" + user.UserId);
        }

        public IActionResult ChangePassword()
        {
            var user = _userService.GetUserByUserName(User.Identity.Name);
            ViewBag.userid = user.UserId;
            return View();
        }


        [HttpPost]

        public IActionResult ChangePassword(ChangePasswordViewModel newpassword)
        {
            if (!ModelState.IsValid)
            {
                return View(newpassword);
            }

            _userService.ChangePassword(User.Identity.Name, newpassword.Password);
            ViewBag.issucces = true;
            var user = _userService.GetUserByUserName(User.Identity.Name);
            ViewBag.userid = user.UserId;
            return View();
        }
    }
}
