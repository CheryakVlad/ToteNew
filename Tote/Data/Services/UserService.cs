using System.Collections.Generic;
using Common.Models;
using Data.Business;
using Data.Clients;

namespace Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserClient userClient;
        private readonly IConvert convert;

        public UserService(IUserClient client, IConvert convert)
        {
            this.userClient = client;
            this.convert = convert;
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
