using Common.Models;

namespace Business.Service
{
    public interface IUpdateUserService
    {
        bool UpdateUser(User user);

        bool AddUser(User user);

        bool DeleteUser(int userId);
    }
}
