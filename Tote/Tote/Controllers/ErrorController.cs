using System;
using System.Web.Mvc;
using Common.Logger;

namespace Tote.Controllers
{
    public class ErrorController : Controller
    {        
        private readonly ILogService<ErrorController> logService;

        public ErrorController():this(new LogService<ErrorController>())
        {

        }
        public ErrorController(ILogService<ErrorController> logService)
        {
            if (logService == null)
            {
                this.logService = new LogService<ErrorController>();
            }
            else
            {
                this.logService = logService;
            }
            
        }
        

        [AllowAnonymous]
        public ActionResult InfoError()
        {
            logService.LogInfoMessage("Controller: ErrorController; Action: InfoError");
            return View();
        }

        [AllowAnonymous]
        public ActionResult InfoDB()
        {
            logService.LogInfoMessage("Controller: ErrorController; Action: InfoDB");
            return View();
        }

        [AllowAnonymous]
        public ActionResult LogAndRedirect(Exception ex)
        {
            logService.LogError(ex.Message + " " + ex.StackTrace);
            return RedirectToAction("InfoError", "Error");
        }
    }
}