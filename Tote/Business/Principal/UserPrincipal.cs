using System.Linq;
using System.Security.Principal;

namespace Business.Principal
{
    public class UserPrincipal : IPrincipal
    {
        public string Login { get; set; }
        public string[] Roles { get; set; }
        public IIdentity Identity
        {
            get; private set;

        }

        public UserPrincipal(string userName)
        {
            Identity = new GenericIdentity(userName);
        }

        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }
    }
}