using System;
using System.Web.Mvc;
using log4net;
using Common.Logger;

namespace Tote.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILog log;
        private readonly ILogService<ErrorController> logService;

        public ErrorController():this(new LogService<ErrorController>()/*LogManager.GetLogger(typeof(ErrorController))*/)
        {

        }
        public ErrorController(ILogService<ErrorController> logService/*ILog log*/)
        {
            if (logService == null)
            {
                this.logService = new LogService<ErrorController>();
            }
            else
            {
                this.logService = logService;
            }
            /*if (log == null)
            {
                log = LogManager.GetLogger(typeof(ErrorController));
            }
            else
            {
                this.log = log;
            }*/
        }
        

        [AllowAnonymous]
        public ActionResult InfoError()
        {
            logService.LogInfoMessage("Controller: ErrorController; Action: InfoError");
            //log.Info("Controller: ErrorController; Action: InfoError");
            return View();
        }

        [AllowAnonymous]
        public ActionResult LogAndRedirect(Exception ex)
        {
            logService.LogError(ex.Message + " " + ex.StackTrace);
            //log.Error(ex.Message + " " + ex.StackTrace);
            return RedirectToAction("InfoError", "Error");
        }
    }
}