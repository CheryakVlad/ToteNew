using Business.Providers;
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

        //[Admin]
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
        //[Admin]
        public ActionResult EditUser(int id)
        {
            User user = userProvider.GetUser(id);
            //IReadOnlyList<Role> roles= userProvider.GetRolesAll();
            SelectList roles = new SelectList(userProvider.GetRolesAll(), "RoleId", "Name");
            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            bool result = userProvider.UpdateUser(user);
            if(!result)
            {
                log.Error("Controller: User, Action: EditUser Don't update user");
            }            
            return RedirectToAction("UsersAll");
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            SelectList roles = new SelectList(userProvider.GetRolesAll(), "RoleId", "Name");
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            bool result = userProvider.AddUser(user);
            if (!result)
            {
                log.Error("Controller: User, Action: AddUser Don't add user");
            }

            return RedirectToAction("UsersAll");
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            User user = userProvider.GetUser(id);
            return View(user);
        }

        [HttpPost]
        [ActionName("DeleteUser")]
        public ActionResult Delete(int userId)
        {
            bool result = userProvider.DeleteUser(userId);
            if (!result)
            {
                log.Error("Controller: User, Action: DeleteUser Don't delete user");
            }
            return RedirectToAction("UsersAll");
        }



        public ActionResult Index()
        {
            return View();
        }
    }
}