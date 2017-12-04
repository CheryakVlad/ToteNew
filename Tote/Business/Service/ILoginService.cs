using Business.Enums;

namespace Business.Service
{
    public interface ILoginService
    {
        LoginResult Login(string userName, string password);
        void Logout();
    }
}