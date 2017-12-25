using Business.Providers;
using System.Web.Mvc;
using Business.Service;
using Business.Principal;
using System;

namespace Tote.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserProvider userProvider;
        private readonly ILoginService loginService;
        private readonly log4net.ILog log;  

        public LoginController(IUserProvider userProvider, ILoginService loginService)
        {
            this.userProvider = userProvider;
            this.loginService = loginService;
            this.log = log4net.LogManager.GetLogger(typeof(LoginController));
        }

        public static LoginController createLoginController(IUserProvider userProvider, ILoginService loginService)
        {
            if (userProvider == null|| loginService == null)
            {
                throw new ArgumentNullException();
            }
            return new LoginController(userProvider, loginService);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {     
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("List", "Navigation");
            } 

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string login, string password)
        {            
            var result = loginService.Login(login, password);
            
            if (result == Business.Enums.LoginResult.NoError)
            {
                return RedirectToAction("List", "Navigation");
            }
            
            if (result == Business.Enums.LoginResult.EmptyCredentials)
            {
                ViewBag.Message = "Check user name and password";
            }
            if (result == Business.Enums.LoginResult.InvalidCredentials)
            {
                ViewBag.Message = "The user is not valid";
            }
            return View();
        }
        
        //[User]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            string role = "";
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                role = (HttpContext.User as UserPrincipal).Roles[0];
            }
            loginService.Logout();
            return RedirectToAction("Login", "Login");
        }

    }
}