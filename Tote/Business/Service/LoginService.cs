using Business.Enums;
using Business.Providers;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Security;

namespace Business.Service
{
    public class LoginService : ILoginService
    {
        private IUserProvider userProvider;

        public LoginService(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }
        public LoginResult Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return LoginResult.EmptyCredentials;
            }

            if (userProvider.IsValidUser(login, password))
            {
                var user = userProvider.ExistsUser(login, password);
                var userData = JsonConvert.SerializeObject(user);
                var ticket = new FormsAuthenticationTicket(2, login, DateTime.Now, DateTime.Now.AddHours(1), false, userData);
                var encTicket = FormsAuthentication.Encrypt(ticket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                HttpContext.Current.Response.Cookies.Add(authCookie);
                return LoginResult.NoError;
            }

            return LoginResult.InvalidCredentials;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
