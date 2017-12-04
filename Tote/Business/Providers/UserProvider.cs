using System;
using System.Collections.Generic;
using Common.Models;
using Data.Services;

namespace Business.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserService userService;
        public UserProvider(IUserService userService)
        {
            this.userService = userService;
        }

        public User ExistsUser(string login, string password)
        {
            return userService.ExistsUser(login, password);
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
    }
}
