using Business.Providers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Common.Models;
using System.ServiceModel;
using System.Data.SqlClient;
using Business.Service;

namespace Tote.Controllers
{
    public class LoginController : Controller
    {
        private IBetListProvider betListProvider;
        private ILoginService loginService;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LoginController));

        public LoginController(IBetListProvider userProvider, ILoginService loginService)
        {
            this.betListProvider = userProvider;
            this.loginService = loginService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            /*User user = betListProvider.ExistsUser("admin","admin");
            if (user == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }*/

            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            //return View();
            var result = loginService.Login(login, password);
            if (result == Business.Enums.LoginResult.NoError)
            {
                return RedirectToAction("List", "Navigation");
            }
            //var model = new LoginViewModel();
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

        public ActionResult Logout()
        {
            //return View();
            loginService.Logout();
            return RedirectToAction("Login", "Login");
        }

    }
}