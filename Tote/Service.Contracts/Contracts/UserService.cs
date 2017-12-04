using System;
using Service.Contracts.Dto;

namespace Service.Contracts.Contracts
{
    public class UserService : IUserService
    {
        public UserDto AddUser()
        {
            throw new NotImplementedException();
        }

        public UserDto EditUser(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto ExistsUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto[] GetUsers()
        {
            throw new NotImplementedException();
        }

        public UserDto[] GetUsersByRole(int RoleId)
        {
            throw new NotImplementedException();
        }
    }
}
