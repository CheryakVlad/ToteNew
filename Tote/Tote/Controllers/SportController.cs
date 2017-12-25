using Business.Providers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tote.Attribute;

namespace Tote.Controllers
{
    public class SportController : Controller
    {
        private readonly IBetListProvider betListProvider;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SportController));

        public SportController(IBetListProvider rateListProvider)
        {            
            this.betListProvider = rateListProvider;
        }

        public static SportController createSportController(IBetListProvider rateListProvider)
        {
            if(rateListProvider==null)
            {
                throw new ArgumentNullException();
            }
            return new SportController(rateListProvider);
        }

        [Editor]
        public ActionResult ShowSports()
        {
            IReadOnlyList<Sport> sports = betListProvider.GetSports();
            if (sports == null)
            {
                return RedirectToAction("InfoError", "Error");
            }
            return PartialView(sports);
        }

        [Editor]
        public ActionResult AddSport()
        {
            return View();
        }

        [HttpPost]
        [Editor]
        public ActionResult AddSport(Sport sport)
        {
            if (ModelState.IsValid)
            {
                bool result = betListProvider.AddSport(sport);
                if (!result)
                {
                    log.Error("Controller: Sport, Action: AddSport Don't add sport");
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
        public ActionResult EditSport(int id)
        {
            Sport sport = betListProvider.GetSport(id);
            if (sport == null)
            {
                log.Error("Controller: Sport, Action: EditSport Don't GetSport");
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
                bool result = betListProvider.UpdateSport(sport);
                if (!result)
                {
                    log.Error("Controller: Sport, Action: EditSport Don't update sport");
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
            Sport sport = betListProvider.GetSport(id);
            if (sport == null)
            {
                log.Error("Controller: Sport, Action: DeleteSport Don't GetSport");
                return RedirectToAction("InfoError", "Error");
            }
            return View(sport);
        }

        [HttpPost]
        [Editor]
        [ActionName("DeleteSport")]
        public ActionResult Delete(int sportId)
        {
            bool result = betListProvider.DeleteSport(sportId);
            if (!result)
            {
                log.Error("Controller: Sport, Action: DeleteUser Don't delete sport");
            }
            return RedirectToAction("ShowSports");
        }
        
    }
}