using Business.Providers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tote.Attribute;
using Business.Service;
using Common.Logger;

namespace Tote.Controllers
{
    [HandleError()]
    public class SportController : Controller
    {
        private const string sportCacheKey = "sportKey";
        
        private readonly ISportProvider sportProvider;
        private readonly ICacheService cacheService;
        private readonly IUpdateSportService sportService;        
        private readonly ILogService<SportController> logService;


        public SportController(ICacheService cacheService, IUpdateSportService sportService, ISportProvider sportProvider) 
            :this(cacheService, sportService, sportProvider, new LogService <SportController>())
        {

        }

        public SportController(ICacheService cacheService, IUpdateSportService sportService, 
            ISportProvider sportProvider, ILogService<SportController> logService)
        {            
            if (cacheService == null || sportService == null || sportProvider == null)
            {
                throw new ArgumentNullException();
            }
            this.cacheService = cacheService;
            this.sportService = sportService;
            this.sportProvider = sportProvider;
            if (logService == null)
            {
                this.logService = new LogService<SportController>();
            }
            else
            {
                this.logService = logService;
            }
        }
        
        [Editor]
        public ActionResult ShowSports()
        {
            logService.LogInfoMessage("Controller: Sport, Action: ShowSports");
            IReadOnlyList<Sport> sports = sportProvider.GetSports();
            if (sports.Count == 0)
            {
                logService.LogError("Controller: Sport, Action: ShowSports Don't show sport");
                return RedirectToAction("InfoError", "Error");
            }
            return PartialView(sports);
        }

        [Editor]
        public ActionResult AddSport()
        {
            logService.LogInfoMessage("Controller: Sport, Action: AddSport");
            return View();
        }

        [HttpPost]
        [Editor]
        public ActionResult AddSport(Sport sport)
        {
            if (ModelState.IsValid)
            {
                bool result = sportService.AddSport(sport);
                if (!result)
                {
                    ModelState.AddModelError("", "You can not add a sport with the following parameters");
                    logService.LogError("Controller: Sport, Action: AddSport Don't add sport");
                    return View(sport);
                }
                else
                {
                    cacheService.DeleteCache(sportCacheKey);
                }
                return RedirectToAction("ShowSports");
            }
            else
            {
                return View(sport);
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult EditSport(int id)
        {
            logService.LogInfoMessage("Controller: Sport, Action: EditSport");
            Sport sport = sportProvider.GetSport(id);
            if (sport == null)
            {
                logService.LogError("Controller: Sport, Action: EditSport Don't GetSport");
                return RedirectToAction("InfoError", "Error");
            }
            return View(sport);
        }

        [HttpPost]
        [Editor]
        public ActionResult EditSport(Sport sport)
        {
            if (ModelState.IsValid)
            {
                bool result = sportService.UpdateSport(sport);
                if (!result)
                {
                    logService.LogError("Controller: Sport, Action: EditSport Don't update sport");
                    ModelState.AddModelError("", "You can not edit a sport with the following parameters");                    
                    return View(sport);
                }
                else
                {
                    cacheService.DeleteCache(sportCacheKey);
                }
                return RedirectToAction("ShowSports");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult DeleteSport(int id)
        {
            logService.LogInfoMessage("Controller: Sport, Action: DeleteSport");
            Sport sport = sportProvider.GetSport(id);
            if (sport == null)
            {
                logService.LogError("Controller: Sport, Action: DeleteSport Don't GetSport");
                return RedirectToAction("InfoError", "Error");
            }
            return View(sport);
        }

        [HttpPost]
        [Editor]
        [ActionName("DeleteSport")]
        public ActionResult Delete(int sportId)
        {            
            bool result = sportService.DeleteSport(sportId);
            if (!result)
            {
                logService.LogError("Controller: Sport, Action: DeleteUser Don't delete sport");
            }
            else
            {
                cacheService.DeleteCache(sportCacheKey);
            }
            return RedirectToAction("ShowSports");
        }
        
    }
}