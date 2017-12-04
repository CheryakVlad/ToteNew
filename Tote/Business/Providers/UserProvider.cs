using System;
using System.Collections.Generic;
using Common.Models;
using Data.Services;
using Data.Clients;

namespace Business.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserService userService;
        private readonly IUserClient userClient;
        public UserProvider(IUserService userService, IUserClient userClient)
        {
            this.userService = userService;
            this.userClient = userClient;
        }

        public User ExistsUser(string login, string password)
        {
            return userService.ExistsUser(login, password);
        }

        public IReadOnlyList<Role> GetRolesAll()
        {
            return userService.GetRolesAll();
        }

        public User GetUser(int id)
        {
            return userService.GetUserById(id);
        }

        public IReadOnlyList<User> GetUsersAll()
        {
            return userService.GetUsersAll();
        }

        public bool IsValidUser(string login, string password)
        {
            var user = userService.ExistsUser(login, password);
            if (user.Login!=null)
            {
                return true;
            }
            return false;
        }

        public bool UpdateUser(User user)
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
        }
    }
}
