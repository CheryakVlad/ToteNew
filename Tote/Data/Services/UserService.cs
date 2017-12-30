using System.Collections.Generic;
using Common.Models;
using Data.Business;
using Data.Clients;
using System;
using Common.Logger;

namespace Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserClient userClient;
        private readonly IConvert convert;
        private readonly ILogService<UserService> logService;

        public UserService(IUserClient userClient, IConvert convert, ILogService<UserService> logService)
        {
            if (userClient == null || convert == null)
            {
                throw new ArgumentNullException();
            }
            this.userClient = userClient;
            this.convert = convert;
            if (logService == null)
            {
                this.logService = new LogService<UserService>();
            }
            else
            {
                this.logService = logService;
            }
        }        

        public User GetUserById(int id)
        {
            var dto = userClient.GetUser(id);

            if (dto != null)
            {
                return convert.ToUser(dto);
            }
            logService.LogError("Class: UserService Method: GetUserById user is null");
            return new User();
        }

        public IReadOnlyList<User> GetUsersAll()
        {
            var dto = userClient.GetUsersAll();

            if (dto != null)
            {
                return convert.ToUsers(dto);
            }
            logService.LogError("Class: UserService Method: GetUsersAll List<User> is null");
            return new List<User>();
        }

        public User ExistsUser(string login, string password)
        {
            var dto = userClient.ExistsUser(login, password);

            if (dto != null)
            {
                return convert.ToUser(dto);
            }
            logService.LogError("Class: UserService Method: ExistsUser User is null");
            return new User();
        }

        public IReadOnlyList<Role> GetRolesAll()
        {
            var dto = userClient.GetRolesAll();

            if (dto != null)
            {
                return convert.ToRoles(dto);
            }
            logService.LogError("Class: UserService Method: GetRolesAll List<Role> is null");
            return new List<Role>();
        }
    }
}
