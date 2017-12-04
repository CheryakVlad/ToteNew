using Common.Models;
using System.Collections.Generic;

namespace Business.Providers
{
    public interface IUserProvider
    {
        User GetUser(int id);
        IReadOnlyList<User> GetUsersAll();
        User ExistsUser(string login, string password);
        bool IsValidUser(string login, string password);

        IReadOnlyList<Role> GetRolesAll();

        bool UpdateUser(User user);

        bool AddUser(User user);

        bool DeleteUser(int userId);
    }
}
