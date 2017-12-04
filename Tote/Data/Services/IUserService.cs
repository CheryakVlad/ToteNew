using Common.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface IUserService
    {
        IReadOnlyList<User> GetUsersAll();
        User GetUserById(int id);

        User ExistsUser(string login, string password);

        IReadOnlyList<Role> GetRolesAll();
    }
}
