using System;
using System.Collections.Generic;
using Common.Models;
using Data.Services;
using Data.Clients;
using Common.Logger;

namespace Business.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserService userService;
        private readonly IUserClient userClient;
        private readonly ILogService<UserProvider> logService;
        public UserProvider(IUserService userService, IUserClient userClient, ILogService<UserProvider> logService)
        {
            if (userService == null || userClient == null)
            {
                throw new ArgumentNullException();
            }
            this.userService = userService;
            this.userClient = userClient;
            if (logService == null)
            {
                this.logService = new LogService<UserProvider>();
            }
            else
            {
                this.logService = logService;
            }
        }

        
        public User ExistsUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login)||string.IsNullOrEmpty(password))
            {
                logService.LogError("Class: UserProvider Method: ExistsUser  login or password is null or empty");
                throw new ArgumentNullException("login or password is null or empty");
            }
            return userService.ExistsUser(login, password);
        }

        public IReadOnlyList<Role> GetRolesAll()
        {
            return userService.GetRolesAll();
        }

        public User GetUser(int id)
        {
            if (id <= 0)
            {
                logService.LogError("Class: UserProvider Method: GetUser  userId must be positive");
                throw new ArgumentOutOfRangeException("userId must be positive");
            }
            return userService.GetUserById(id);
        }

        public IReadOnlyList<User> GetUsersAll()
        {
            return userService.GetUsersAll();
        }

        public bool IsValidUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                logService.LogError("Class: UserProvider Method: IsValidUser  login or password is null or empty");
                throw new ArgumentNullException("login or password is null or empty");
            }
            var user = userService.ExistsUser(login, password);
            if (user.Login!=null)
            {
                return true;
            }
            return false;
        }

        /*public bool UpdateUser(User user)
        {
            
            return userClient.UpdateUser(user);
        }

        public bool AddUser(User user)
        {
            return userClient.AddUser(user);
        }

        public bool DeleteUser(int userId)
        {
            return userClient.DeleteUser(userId);
        }*/
    }
}
