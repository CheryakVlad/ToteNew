﻿using Business.Providers;
using Common.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Tote.Attribute;

namespace Tote.Controllers
{
    public class UserController : Controller
    {
        private IUserProvider userProvider;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(UserController));

        public UserController(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }
        [Admin]
        public ActionResult UsersAll()
        {
            IReadOnlyList<User> users = userProvider.GetUsersAll();
            if (users == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(users);
        }

        [HttpGet]
        [Admin]
        public ActionResult EditUser(int id)
        {
            User user = userProvider.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}