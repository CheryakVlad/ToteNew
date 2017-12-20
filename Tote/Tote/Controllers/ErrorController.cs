using System;
using System.Web.Mvc;

namespace Tote.Controllers
{
    public class ErrorController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ErrorController));

        [AllowAnonymous]
        public ActionResult InfoError()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult LogAndRedirect(Exception ex)
        {
            log.Error(ex.Message + " " + ex.StackTrace);
            return RedirectToAction("InfoError", "Error");
        }
    }
}