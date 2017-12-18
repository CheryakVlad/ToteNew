using Business.Providers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Common.Models;
using System.ServiceModel;
using System.Data.SqlClient;
using Business.Service;
using Business.Principal;
using Tote.Attribute;

namespace Tote.Controllers
{
    public class LoginController : Controller
    {
        private IUserProvider userProvider;
        private ILoginService loginService;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LoginController));

        public LoginController(IUserProvider userProvider, ILoginService loginService)
        {
            this.userProvider = userProvider;
            this.loginService = loginService;
        }

        

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
           
            
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("List", "Navigation");
            }

            /*User user = userProvider.ExistsUser("admin","admin");
            if (user == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }*/

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
        
        [User]
        public ActionResult Logout()
        {
            loginService.Logout();
            return RedirectToAction("Login", "Login");
        }

    }
}