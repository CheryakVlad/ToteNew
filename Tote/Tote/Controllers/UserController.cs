using Business.Principal;
using Business.Providers;
using Business.Service;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tote.Attribute;
using Common.Logger;

namespace Tote.Controllers
{
    public class UserController : Controller
    {
        private readonly IBetListProvider betListProvider;
        private readonly IUserProvider userProvider;
        private readonly ILoginService loginService;
        private readonly IUpdateUserService userService;        
        private readonly ILogService<UserController> logService;

        public UserController(IUserProvider userProvider, IBetListProvider betListProvider, ILoginService loginService, IUpdateUserService userService) 
            :this(userProvider, betListProvider, loginService, userService, new LogService<UserController>())
        {

        }

        public UserController(IUserProvider userProvider, IBetListProvider betListProvider, 
            ILoginService loginService, IUpdateUserService userService, ILogService<UserController> logService)
        {
            if (logService == null)
            {
                this.logService = new LogService<UserController>();
            }
            else
            {
                this.logService = logService;
            }
            if (betListProvider == null || userProvider == null || loginService == null|| userService==null)
            {
                logService.LogError("UserController ArgumentNullException");
                throw new ArgumentNullException();
            }
            this.userProvider = userProvider;
            this.betListProvider = betListProvider;
            this.loginService = loginService;
            this.userService = userService;
            
        }
        
        [Admin]
        public ActionResult UsersAll()
        {
            logService.LogInfoMessage("Controller: User, Action: UsersAll");
            IReadOnlyList<User> users = userProvider.GetUsersAll();
            if (users == null)
            {
                logService.LogError("Controller: User, Action: UsersAll Don't GetUsersAll");
                return RedirectToAction("InfoError", "Error");
            }
            return View(users);
        }

        [HttpGet]
        [Admin]
        public ActionResult EditUser(int id)
        {
            logService.LogInfoMessage("Controller: User, Action: EditUser");
            User user = userProvider.GetUser(id);
            if (user == null)
            {
                logService.LogError("Controller: User, Action: EditUser Don't GetUser");
                return RedirectToAction("InfoError", "Error");
            }
            user.ConfirmPassword = user.Password;
            SelectList roles = new SelectList(userProvider.GetRolesAll(), "RoleId", "Name", user.Roles[0].RoleId);
            if (roles == null)
            {
                logService.LogError("Controller: User, Action: EditUser Don't GetRolesAll");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Roles = roles;
            return View(user);
        }

        private SelectList GetRolesAll(int roleId)
        {
            IReadOnlyList<Role> rolesAll = userProvider.GetRolesAll();
            if (rolesAll.Count == 0)
            {
                logService.LogError("Controller: User, Don't GetRolesAll");
                return null;
            }
            SelectList roles = new SelectList(rolesAll, "RoleId", "Name", roleId);
            
            return roles;
        }

        [HttpPost]
        [Admin]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {                
                bool result = userService.UpdateUser(user);

                if (!result)
                {
                    ModelState.AddModelError("", "You can not edit a user with the following parameters");
                    logService.LogError("Controller: User, Action: EditUser Don't update user");
                                       
                    SelectList roles = GetRolesAll(user.Roles[0].RoleId);
                    if(roles==null)
                    {
                        return RedirectToAction("InfoError", "Error");
                    }
                    ViewBag.Roles = roles;

                    return View(user);
                    
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
                SelectList roles = GetRolesAll(user.Roles[0].RoleId);
                if (roles == null)
                {
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Roles = roles;
                return View(user);
            }            
        }       
        

        [HttpGet]
        [Admin]
        public ActionResult AddUser()
        {
            logService.LogInfoMessage("Controller: User, Action: AddUser");
            SelectList roles = GetRolesAll(1);
            if (roles == null)
            {
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
                bool result = userService.AddUser(user);
                if (!result)
                {
                    ModelState.AddModelError("", "You can not add a user with the following parameters");
                    logService.LogError("Controller: User, Action: EditUser Don't add user");

                    SelectList roles = GetRolesAll(user.Roles[0].RoleId);
                    if (roles == null)
                    {
                        return RedirectToAction("InfoError", "Error");
                    }
                    ViewBag.Roles = roles;

                    return View(user);                    
                }

                return RedirectToAction("UsersAll");
            }
            else
            {
                SelectList roles = GetRolesAll(user.Roles[0].RoleId);
                if (roles == null)
                {
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Roles = roles;
                return View(user);
            }
        }

        [HttpGet]
        [Admin]
        public ActionResult DeleteUser(int id)
        {
            logService.LogInfoMessage("Controller: User, Action: DeleteUser");
            User user = userProvider.GetUser(id);
            IReadOnlyList<Role> roles = userProvider.GetRolesAll();
            if (roles.Count == 0)
            {
                logService.LogError("Controller: User, Action: DeleteUser Don't GetRolesAll");
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
            bool result = userService.DeleteUser(userId);
            if (!result)
            {
                logService.LogError("Controller: User, Action: DeleteUser Don't delete user");
            }
            return RedirectToAction("UsersAll");
        }


        [HttpGet]
        [User]        
        public ActionResult ShowUserProfile()
        {
            logService.LogInfoMessage("Controller: User, Action: ShowUserProfile User:"+ (HttpContext.User as UserPrincipal).Login);
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            User user = userProvider.GetUser(userId);
            if (user == null)
            {
                logService.LogError("Controller: User, Action: ShowUserProfile Don't GetUser");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Rates = betListProvider.GetRateByUserId(userId);
            return View(user);
        }

        [HttpGet]
        [User]        
        public ActionResult EditUserProfile()
        {
            logService.LogInfoMessage("Controller: User, Action: EditUserProfile User:" + (HttpContext.User as UserPrincipal).Login);
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            User user = userProvider.GetUser(userId);
            if (user == null)
            {
                logService.LogError("Controller: User, Action: ShowUserProfile Don't GetUser");
                return RedirectToAction("InfoError", "Error");
            }
            user.ConfirmPassword = user.Password;
            return View(user);
        }

        [HttpPost]
        [User]        
        public ActionResult EditUserProfile(User user)
        {
            if (ModelState.IsValid)
            {
                bool result = userService.UpdateUser(user);
                if (!result)
                {
                    ModelState.AddModelError("", "You can not add a user with the following parameters");
                    logService.LogError("Controller: User, Action: EditUser Don't edit user");

                    SelectList roles = GetRolesAll(user.Roles[0].RoleId);
                    if (roles == null)
                    {
                        return RedirectToAction("InfoError", "Error");
                    }
                    ViewBag.Roles = roles;

                    return View(user);
                }
                               
                return RedirectToAction("ShowUserProfile");
            }
            else
            {
                SelectList roles = GetRolesAll(user.Roles[0].RoleId);
                if (roles == null)
                {
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Roles = roles;
                return View(user);
            }
        }
    }
}