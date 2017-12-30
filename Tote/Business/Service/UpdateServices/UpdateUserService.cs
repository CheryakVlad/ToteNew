using System;
using Common.Models;
using Data.Clients;
using Common.Logger;

namespace Business.Service
{
    public class UpdateUserService : IUpdateUserService
    {        
        private readonly IUserClient userClient;
        private readonly ILogService<UpdateUserService> logService;
        public UpdateUserService( IUserClient userClient, ILogService<UpdateUserService> logService)
        {
            if (userClient == null)
            {
                throw new ArgumentNullException();
            }            
            this.userClient = userClient;
            if (logService == null)
            {
                this.logService = new LogService<UpdateUserService>();
            }
            else
            {
                this.logService = logService;
            }
        }

        public bool AddUser(User user)
        {
            if (user == null)
            {
                logService.LogError("Class: UpdateUserService Method: AddUser  User don't add to DB");
                throw new ArgumentNullException("User is null");
            }
            return userClient.AddUser(user);
        }

        public bool DeleteUser(int userId)
        {
            if (userId <= 0)
            {
                logService.LogError("Class: UpdateUserService Method: DeleteUser  User don't delete from DB");
                throw new ArgumentOutOfRangeException("userId <= 0");
            }
            return userClient.DeleteUser(userId);
        }

        bool IUpdateUserService.UpdateUser(User user)
        {
            if (user == null)
            {
                logService.LogError("Class: UpdateUserService Method: UpdateUser  User don't update to DB");
                throw new ArgumentNullException("User is null");
            }            
            return userClient.UpdateUser(user);
        }
    }
}
