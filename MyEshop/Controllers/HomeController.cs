using Microsoft.AspNetCore.Mvc;
using MyEshop.Models;
using System.Diagnostics;
using System.Security.Claims;
using Core;
using Core.Convertors;
using DataLayer;
using DataLayer.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SendEmail;
using Microsoft.AspNetCore.Authorization;

namespace MyEshop.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly ILogger<HomeController> _logger;

        private IUserService _userService;
        private IViewRenderService _viewRenderService;
        IProductService _productService;
        public HomeController(ILogger<HomeController> logger, IUserService userService, IViewRenderService viewRenderService,IProductService productService)
        {
            _logger = logger;
            _userService = userService;
            _viewRenderService = viewRenderService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.MostPopularProducts();
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var username = FixText.FixEmail(user.Name);
            var email = FixText.FixEmail(user.Email);

            if (_userService.IsExistUser(username, email))
            {
                ModelState.AddModelError("Name", "نام کاربری یا ایمیل از قبل وجود دارد");
                return View(user);
            }

            User user1 = new User()
            {
                Name = username,
                AvatarName= "Defaulte.jpg",
                Email = email,
                IsActive = false,
                IsDelete = false,
                RegisterDate = DateTime.Now,
                Password = HashPassword.EncodePasswordMd5(user.Password),
                ActiveCode = NameGenerator.GenerateUnique()
            };

            _userService.AddUser(user1);

            #region SendEmail

            string body = _viewRenderService.RenderToStringAsync("_ActiveCode", user1);

            Core.SendEmail.Send(email, "فعالسازی حساب کاربری", body);

            #endregion


            return View("_SuccessfulRegister");
        }

        [Authorize]
        public IActionResult ActiveAccount(string id)
        {
            ViewBag.isActive = _userService.ActiveAccount(id);
            return View();
        }

    
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {

            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userService.Login(login.Name, login.Password);

            if (user == null)
            {
                ModelState.AddModelError("Name", "کاربری با این مشخصات وجود ندارد");
                return View(login);
            }


            if (!user.IsActive)
            {
                ModelState.AddModelError("Name", "حساب کاربری شما فعال نیست لطفا ابتدا حساب خود را فعال کنید");
                return View(login);
            }

            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId .ToString()),
                        new Claim(ClaimTypes.Name , user.Name),

                    };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);
            ViewBag.issucces = true;

            return Redirect("/UserPanel/Home/Index/" + user.UserId);

        }


        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Home/Login");
        }

        [Authorize]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(ForgetPassword model)
        {
            
            var user = _userService.GetUserByEmail(model.Email);

            if (user==null)
            {
                ModelState.AddModelError("Email","کاربری با این ایمیل وجود ندارد");
                return View(model);
            }

          string body= _viewRenderService.RenderToStringAsync("_SendActivationCodeForResetPassword", user);

          Core.SendEmail.Send(model.Email,"بازیابی اطلاعات کاربری",body);

            return View("ResetPassword");
        }


        public IActionResult ResetPassword(string id)
        {
            var user = _userService.GetUserByActiveCode(id);

            if (user==null)
            {
                return NotFound();
            }

            ViewBag.activecode = id;
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(string activeCode,ResetPassword user)
        {
            var user1=_userService.GetUserByActiveCode(activeCode);

            var hashpassword = HashPassword.EncodePasswordMd5(user.Password);

            user1.Password= hashpassword;

            _userService.UpdateUser(user1);

            return View("_SuccessFulUpdatePassword");
        }

        
    }
}
