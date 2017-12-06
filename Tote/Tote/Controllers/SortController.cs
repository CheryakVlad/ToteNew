using Business.Providers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace Tote.Controllers
{
    public class SortController : Controller
    {
        private IBetListProvider betListProvider;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SortController));

        public SortController(IBetListProvider rateListProvider)
        {
            this.betListProvider = rateListProvider;
        }
        [HttpGet]
        public ActionResult Sort()
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            string[] statuses=new string[]{ "Past Events","Current Events","Furure Events"};
            SelectList status = new SelectList(statuses);
            ViewBag.Statuses = status;
            IReadOnlyList<Match> bets = betListProvider.GetMatchesAll();
            if (bets.Count == 0)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(bets);
        }
        [HttpGet]
        public ActionResult Match(int sportId)
        {                       
            IReadOnlyList<Match> bets = new List<Match>();
            try
            {
                bets = betListProvider.GetBetList(sportId, 0);
                if (bets == null)
                {
                    return RedirectToAction("InfoError", "Navigation");
                }
            }
            catch (FaultException faultEx)
            {
                LogAndRedirect(faultEx);
            }
            catch (SqlException sqlEx)
            {
                LogAndRedirect(sqlEx);
            }

            return PartialView(bets);
        }
        public ActionResult LogAndRedirect(Exception ex)
        {
            log.Error(ex.Message + " " + ex.StackTrace);
            return RedirectToAction("InfoError", "Navigation");
        }
    }
}