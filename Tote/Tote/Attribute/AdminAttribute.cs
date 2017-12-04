
using Business.Principal;
using System.Web;
using System.Web.Mvc;

namespace Tote.Attribute
{
    public class AdminAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.User as UserPrincipal;
            if (!user.IsInRole("Admin"))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Navigation", action = "List" }));
            }

        }
    }
}