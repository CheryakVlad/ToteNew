using Business.Principal;
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
        private readonly IBetListProvider betListProvider;
        private readonly IMatchProvider matchProvider;
        private readonly IUserProvider userProvider;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SortController));

        public SortController(IBetListProvider rateListProvider, IMatchProvider matchProvider, IUserProvider userProvider)
        {
            this.betListProvider = rateListProvider;
            this.matchProvider = matchProvider;
            this.userProvider = userProvider;
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
        public ActionResult ShowCoefficient(int matchId, int eventId)
        {
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            Basket basket = new Basket()
            {
                MatchId = matchId,
                EventId = eventId,
                UserId=userId
            };
            betListProvider.AddBasket(basket);
            return RedirectToAction("Sorting");
        }

        [HttpGet]
        public ActionResult ShowBasket()
        {
            double total = 1;
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            IReadOnlyList<Basket> baskets = betListProvider.GetBasketByUser(userId,out total);
            ViewBag.Total = total;
            return View(baskets);
        }

        [HttpGet]
        public ActionResult DeleteBasket(int basketId)
        {
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            Basket basket = betListProvider.GetBasketById(basketId, userId);
            return View(basket);
        }

        [HttpPost]
        [ActionName("DeleteBasket")]
        public ActionResult Delete(int basketId)
        {            
            bool delete = betListProvider.DeleteBasket(basketId);
            if (!delete)
            {
                log.Error("Controller: Sort, Action: DeleteBasket Don't delete BasketItem");
            }
            return RedirectToAction("ShowBasket");
        }

        [HttpGet]
        public ActionResult MakeRate()
        {
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            User user = userProvider.GetUser(userId);
            return View(user);
        }

        [HttpPost]
        public ActionResult MakeRate(decimal amount)
        {
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            Rate rate = new Rate()
            {
                Amount=amount,
                DateRate=DateTime.Now,
                UserId=userId
            };
            User user = userProvider.GetUser(userId);
            user.Money -= amount;
            userProvider.UpdateUser(user);
            int rateId = betListProvider.AddRate(rate);
            double total = 1;
            IReadOnlyList<Basket> baskets = betListProvider.GetBasketByUser(userId, out total);
            foreach(Basket basket in baskets)
            {
                Bet bet = new Bet()
                {
                    RateId=rateId,
                    MatchId=basket.MatchId,
                    Event=new Event { EventId=basket.EventId}
                };
                betListProvider.AddBet(bet, basket.BasketId);
            }
            return View();
        }

    }
}