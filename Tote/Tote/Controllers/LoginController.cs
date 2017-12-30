using Business.Providers;
using System.Web.Mvc;
using Business.Service;
using Business.Principal;
using System;
using log4net;
using Tote.Attribute;
using Common.Logger;

namespace Tote.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserProvider userProvider;
        private readonly ILoginService loginService;
        private readonly ILog log;
        private readonly ILogService<LoginController> logService;

        /*public LoginController(IUserProvider userProvider, ILoginService loginService)
        {
            this.userProvider = userProvider;
            this.loginService = loginService;
            this.log = log4net.LogManager.GetLogger(typeof(LoginController));
        }*/

        public LoginController(IUserProvider userProvider, ILoginService loginService) 
            :this(userProvider, loginService, new LogService<LoginController>() /*LogManager.GetLogger(typeof(LoginController))*/)
        {

        }

        public LoginController(IUserProvider userProvider, ILoginService loginService, ILogService<LoginController> logService /*ILog log*/)
        {
            if (userProvider == null || loginService == null)
            {
                throw new ArgumentNullException();
            }
            this.userProvider = userProvider;
            this.loginService = loginService;
            if (logService == null)
            {
                this.logService = new LogService<LoginController>();
            }
            else
            {
                this.logService = logService;
            }
            /*if (log == null)
            {
                this.log = LogManager.GetLogger(typeof(LoginController));
            }
            else
            {
                this.log = log;
            }*/
        }

        /*public static LoginController createLoginController(IUserProvider userProvider, ILoginService loginService)
        {
            if (userProvider == null|| loginService == null)
            {
                throw new ArgumentNullException();
            }
            return new LoginController(userProvider, loginService);
        }*/

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
                logService.LogInfoMessage("user: "+login+" login");
                return RedirectToAction("List", "Navigation");
            }            
            if (result == Business.Enums.LoginResult.EmptyCredentials)
            {
                logService.LogInfoMessage("Check user name and password for "+login);
                ViewBag.Message = "Check user name and password";
            }
            if (result == Business.Enums.LoginResult.InvalidCredentials)
            {
                logService.LogInfoMessage("The user is not valid for " + login);
                ViewBag.Message = "The user is not valid";
            }
            return View();
        }
        
        [User]
        //[AllowAnonymous]
        public ActionResult Logout()
        {
            string role = "";
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                role = (HttpContext.User as UserPrincipal).Roles[0];
                logService.LogInfoMessage("The user "+ (HttpContext.User as UserPrincipal).Login + " is logout");
            }
            loginService.Logout();
            return RedirectToAction("Login", "Login");
        }

    }
}