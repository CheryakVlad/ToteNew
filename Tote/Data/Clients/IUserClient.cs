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
    }
}
