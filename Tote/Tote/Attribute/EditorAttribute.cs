﻿using Business.Principal;
using System.Web;
using System.Web.Mvc;

namespace Tote.Attribute
{
    public class EditorAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Navigation", action = "List" }));
                return;
            }

            var user = HttpContext.Current.User as UserPrincipal;
            if (!user.IsInRole("Editor") && !user.IsInRole("Admin"))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Navigation", action = "List" }));
            }

        }

    }
}