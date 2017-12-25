using System;
using System.Web.Mvc;
using log4net;

namespace Tote.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILog log;

        public ErrorController()
        {
            log = log4net.LogManager.GetLogger(typeof(ErrorController));
        }

        [AllowAnonymous]
        public ActionResult InfoError()
        {
            log.Info("Controller: ErrorController; Action: InfoError");
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