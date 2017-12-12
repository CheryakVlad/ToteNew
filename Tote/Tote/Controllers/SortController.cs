using Business.Providers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using Tote.Attribute;

namespace Tote.Controllers
{
    public class SortController : Controller
    {
        private const string cacheKey = "cacheKey";
        private IBetListProvider betListProvider;
        private readonly IMatchProvider matchProvider;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SortController));

        public SortController(IBetListProvider rateListProvider, IMatchProvider matchProvider)
        {
            this.betListProvider = rateListProvider;
            this.matchProvider = matchProvider;
        }
        public ActionResult Sorting()
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            string[] statuses = new string[] { "Past Events", "Current Events", "Furure Events" };
            SelectList status = new SelectList(statuses);
            ViewBag.Statuses = status;

            IReadOnlyList<Match> matches = HttpRuntime.Cache.Get(cacheKey) as IReadOnlyList<Match>;
            if (matches == null)
            {
                matches = matchProvider.GetMatchBySportDateStatus(0, "", 0);
                HttpRuntime.Cache.Insert(cacheKey, matches, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
            }

            //IReadOnlyList<Match> matches = matchProvider.GetMatchBySportDateStatus(0,"",0);
            if (matches.Count == 0)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(matches);
            /*IReadOnlyList<Match> bets = betListProvider.GetMatchesAll();
            if (bets.Count == 0)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(bets);*/
        }
        [HttpGet]
        public ActionResult Sort()
        {            
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            string[] statuses=new string[]{ "Past Events","Current Events","Furure Events"};
            SelectList status = new SelectList(statuses);
            ViewBag.Statuses = status;

            IReadOnlyList<Match> matches = HttpRuntime.Cache.Get(cacheKey) as IReadOnlyList<Match>;
            if(matches==null)
            {
                matches = matchProvider.GetMatchBySportDateStatus(0, "", 0);
                HttpRuntime.Cache.Insert(cacheKey,matches, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
            }

            //IReadOnlyList<Match> matches = matchProvider.GetMatchBySportDateStatus(0,"",0);
            if (matches.Count == 0)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(matches);
            /*IReadOnlyList<Match> bets = betListProvider.GetMatchesAll();
            if (bets.Count == 0)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(bets);*/
        }

        [HttpGet]
        public ActionResult Match(int sportId, string dateMatch, int status)
        {
            /*IReadOnlyList<Match> bets = new List<Match>();
            try
            {
                bets = betListProvider.GetBetList(sportId, 0);
                if (bets == null)
                {
                    return RedirectToAction("InfoError", "Navigation");
                }
            }*/
            string cache = sportId.ToString() + dateMatch + status.ToString();
            IReadOnlyList<Match> matches = HttpRuntime.Cache.Get(cache) as IReadOnlyList<Match>;
            

            //IReadOnlyList<Match> matches = new List<Match>();
            try
            {
                if (matches == null)
                {
                    matches = matchProvider.GetMatchBySportDateStatus(sportId, dateMatch, status);
                    HttpRuntime.Cache.Insert(cache, matches, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
                }
                //matches = matchProvider.GetMatchBySportDateStatus(sportId, dateMatch, status);
                if (matches == null)
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

            return PartialView(matches);
        }
        public ActionResult LogAndRedirect(Exception ex)
        {
            log.Error(ex.Message + " " + ex.StackTrace);
            return RedirectToAction("InfoError", "Navigation");
        }

        [Json]
        
        public JsonResult AjaxMethod(int sportId, string dateMatch, int status)
        {

            string cache = sportId.ToString() + dateMatch + status.ToString();
            IReadOnlyList<Match> matches = HttpRuntime.Cache.Get(cache) as IReadOnlyList<Match>;
            try
            {
                if (matches == null)
                {
                    matches = matchProvider.GetMatchBySportDateStatus(sportId, dateMatch, status);
                    HttpRuntime.Cache.Insert(cache, matches, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
                }
                //matches = matchProvider.GetMatchBySportDateStatus(sportId, dateMatch, status);
                if (matches == null)
                {
                    return Json(string.Empty, JsonRequestBehavior.AllowGet);
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

            return Json(matches, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ShowCoefficient(int matchId)
        {
            ViewBag.Match = matchId;
            IReadOnlyList<Event> events = matchProvider.GetEventByMatch(matchId);
            if (events == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }

            return View(events);
        }

        [HttpPost]
        public ActionResult ShowCoefficient(int matchId, int eventId, string login)
        {
            Basket basket = new Basket()
            {
                MatchId = matchId,
                EventId = eventId,
                Login=login
            };
            betListProvider.AddBasket(basket);
            return RedirectToAction("Sorting");
        }

        [HttpGet]
        public ActionResult ShowBasket()
        {

            return View();
        }
    }
}