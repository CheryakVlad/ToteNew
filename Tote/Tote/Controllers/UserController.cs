using Business.Principal;
using Business.Providers;
using Business.Service;
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
        private readonly ILoginService loginService;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(UserController));

        public UserController(IUserProvider userProvider, IBetListProvider betListProvider, ILoginService loginService)
        {
            this.userProvider = userProvider;
            this.betListProvider = betListProvider;
            this.loginService = loginService;
            
        }

        [Admin]
        public ActionResult UsersAll()
        {
            IReadOnlyList<User> users = userProvider.GetUsersAll();
            if (users == null)
            {
                log.Error("Controller: User, Action: UsersAll Don't GetUsersAll");
                return RedirectToAction("InfoError", "Error");
            }
            return View(users);
        }

        [HttpGet]
        [Admin]
        public ActionResult EditUser(int id)
        {
            User user = userProvider.GetUser(id);
            if (user == null)
            {
                log.Error("Controller: User, Action: EditUser Don't GetUser");
                return RedirectToAction("InfoError", "Error");
            }
            user.ConfirmPassword = user.Password;
            SelectList roles = new SelectList(userProvider.GetRolesAll(), "RoleId", "Name", user.RoleId);
            if (roles == null)
            {
                log.Error("Controller: User, Action: EditUser Don't GetRolesAll");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Roles = roles;
            return View(user);
        }

        [HttpPost]
        [Admin]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                bool result = userProvider.UpdateUser(user);
                
                if (!result)
                {
                    log.Error("Controller: User, Action: EditUser Don't update user");
                }
                int userId = (HttpContext.User as UserPrincipal).UserId;
                if (userId==user.UserId)
                {
                    loginService.Login(user.Login, user.Password);
                }
                return RedirectToAction("UsersAll");
            }  
            else
            {
                SelectList roles = new SelectList(userProvider.GetRolesAll(), "RoleId", "Name", user.RoleId);
                if (roles == null)
                {
                    log.Error("Controller: User, Action: EditUser Don't GetRolesAll");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Roles = roles;                
                return View();
            }
            
        }

        /*[HttpGet]
        public ActionResult Edit()
        {
            User user = userProvider.GetUser(4);
            //IReadOnlyList<Role> roles= userProvider.GetRolesAll();
            SelectList roles = new SelectList(userProvider.GetRolesAll(), "RoleId", "Name", user.RoleId);
            ViewBag.Roles = roles;
            return View(user);
        }*/

        [HttpGet]
        [Admin]
        public ActionResult AddUser()
        {
            SelectList roles = new SelectList(userProvider.GetRolesAll(), "RoleId", "Name");
            if (roles == null)
            {
                log.Error("Controller: User, Action: AddUser Don't GetRolesAll");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        [Admin]
        public ActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                bool result = userProvider.AddUser(user);
                if (!result)
                {
                    log.Error("Controller: User, Action: AddUser Don't add user");
                }

                return RedirectToAction("UsersAll");
            }
            else
            {
                SelectList roles = new SelectList(userProvider.GetRolesAll(), "RoleId", "Name");
                if (roles == null)
                {
                    log.Error("Controller: User, Action: AddUser Don't GetRolesAll");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Roles = roles;
                return View();
            }
        }

        [HttpGet]
        [Admin]
        public ActionResult DeleteUser(int id)
        {
            User user = userProvider.GetUser(id);
            IReadOnlyList<Role> roles = userProvider.GetRolesAll();
            if (roles == null)
            {
                log.Error("Controller: User, Action: DeleteUser Don't GetRolesAll");
                return RedirectToAction("InfoError", "Error");
            }
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
        [Admin]
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
        [User]        
        public ActionResult ShowUserProfile()
        {
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            User user = userProvider.GetUser(userId);
            if (user == null)
            {
                log.Error("Controller: User, Action: ShowUserProfile Don't GetUser");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Rates = betListProvider.GetRateByUserId(userId);
            return View(user);
        }
        [HttpGet]
        [User]
        
        public ActionResult EditUserProfile()
        {
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            User user = userProvider.GetUser(userId);
            if (user == null)
            {
                log.Error("Controller: User, Action: ShowUserProfile Don't GetUser");
                return RedirectToAction("InfoError", "Error");
            }
            user.ConfirmPassword = user.Password;
            return View(user);
        }

        [HttpPost]
        [User]        
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