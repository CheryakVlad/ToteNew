using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Clients
{
    public interface IUserClient
    {
        UserService.UserDto GetUser(int userId);
        IReadOnlyList<UserService.UserDto> GetUsersAll();

        UserService.UserDto ExistsUser(string login, string password);

        IReadOnlyList<UserService.RoleDto> GetRolesAll();

        bool UpdateUser(User user);

        bool AddUser(User user);

        bool DeleteUser(int userId);
    }
}
