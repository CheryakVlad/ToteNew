using Business.Principal;
using Business.Providers;
using Common.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Tote.Attribute;

namespace Tote.Controllers
{
    public class UserController : Controller
    {
        private readonly IBetListProvider betListProvider;
        private readonly IUserProvider userProvider;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(UserController));

        public UserController(IUserProvider userProvider, IBetListProvider betListProvider)
        {
            this.userProvider = userProvider;
            this.betListProvider = betListProvider;
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
            SelectList roles = new SelectList(userProvider.GetRolesAll(), "RoleId", "Name", user.RoleId);
            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                bool result = userProvider.UpdateUser(user);
                if (!result)
                {
                    log.Error("Controller: User, Action: EditUser Don't update user");
                }
            }         
            return RedirectToAction("UsersAll");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            User user = userProvider.GetUser(4);
            //IReadOnlyList<Role> roles= userProvider.GetRolesAll();
            SelectList roles = new SelectList(userProvider.GetRolesAll(), "RoleId", "Name", user.RoleId);
            ViewBag.Roles = roles;
            return View(user);
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
            IReadOnlyList<Role> roles = userProvider.GetRolesAll();
            Role role = new Role();
            foreach(var _role in roles)
            {
                if(_role.RoleId==user.RoleId)
                {
                    role = _role;
                    break;
                }
            }
            ViewBag.Role = role.Name;
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


        [HttpGet]
        public ActionResult ShowUserProfile()
        {
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            User user = userProvider.GetUser(userId);
            ViewBag.Rates = betListProvider.GetRateByUserId(userId);
            return View(user);
        }
        [HttpGet]
        public ActionResult EditUserProfile(int userId)
        {
            User user = userProvider.GetUser(userId);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUserProfile(User user)
        {
            bool result = userProvider.UpdateUser(user);
            if (!result)
            {
                log.Error("Controller: User, Action: EditUser Don't update user");
            }
            return RedirectToAction("ShowUserProfile");
        }
        

    }
}