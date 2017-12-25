using System.Collections.Generic;
using Common.Models;
using Data.Business;
using Data.Clients;
using System;

namespace Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserClient userClient;
        private readonly IConvert convert;

        public UserService(IUserClient userClient, IConvert convert)
        {
            this.userClient = userClient;
            this.convert = convert;
        }

        public static UserService createUserService(IUserClient userClient, IConvert convert)
        {
            if (userClient == null || convert == null)
            {
                throw new ArgumentNullException();
            }
            return new UserService(userClient, convert);
        }

        public User GetUserById(int id)
        {
            var dto = userClient.GetUser(id);

            if (dto != null)
            {
                return convert.ToUser(dto);
            }
            return new User();
        }

        public IReadOnlyList<User> GetUsersAll()
        {
            var dto = userClient.GetUsersAll();

            if (dto != null)
            {
                return convert.ToUsers(dto);
            }
            return new List<User>();
        }

        public User ExistsUser(string login, string password)
        {
            var dto = userClient.ExistsUser(login, password);

            if (dto != null)
            {
                return convert.ToUser(dto);
            }
            return new User();
        }

        public IReadOnlyList<Role> GetRolesAll()
        {
            var dto = userClient.GetRolesAll();

            if (dto != null)
            {
                return convert.ToRoles(dto);
            }
            return new List<Role>();
        }
    }
}
