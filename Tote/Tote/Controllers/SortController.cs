using Business.Principal;
using Business.Providers;
using Business.Service;
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
        private const string cacheKey = "sortKey";
        private readonly IBetListProvider betListProvider;
        private readonly IMatchProvider matchProvider;
        private readonly IUserProvider userProvider;
        private readonly ICacheService cacheService;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SortController));

        public SortController(IBetListProvider rateListProvider, IMatchProvider matchProvider, IUserProvider userProvider, ICacheService cacheService)
        {
            this.betListProvider = rateListProvider;
            this.matchProvider = matchProvider;
            this.userProvider = userProvider;
            this.cacheService = cacheService;
        }
        public ActionResult Sorting()
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            string[] statuses = new string[] { "Past Events", "Current Events", "Furure Events" };
            SelectList status = new SelectList(statuses);
            ViewBag.Statuses = status;

            IReadOnlyList<Match> matches = cacheService.GetCache(0, "", 0);
            if (matches == null)
            {
                matches = cacheService.InsertCache(0, "", 0);               
            }
            
            if (matches.Count == 0)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(matches);
            
        }
        [HttpGet]
        public ActionResult Sort()
        {            
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            string[] statuses=new string[]{ "Past Events","Current Events","Furure Events"};
            SelectList status = new SelectList(statuses);
            ViewBag.Statuses = status;

            IReadOnlyList<Match> matches = cacheService.GetCache(0, "", 0);
            if (matches == null)
            {
                matches = cacheService.InsertCache(0, "", 0);               
            }

            
            if (matches.Count == 0)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(matches);
            
        }

        [HttpGet]
        public ActionResult Match(int sportId, string dateMatch, int status)
        {            
            string cache = sportId.ToString() + dateMatch + status.ToString();
            IReadOnlyList<Match> matches = cacheService.GetCache(sportId, dateMatch, status); 
            
            try
            {
                if (matches == null)
                {
                    matches = cacheService.InsertCache(sportId, dateMatch, status);
                }
                
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
            Match match = matchProvider.GetMatchById(matchId);
            ViewBag.MatchDate = match.Date;
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

        [HttpGet]
        public ActionResult ShowBetsByRate(int rateId)
        {
            double total = 1;
            IReadOnlyList<Bet> bets = betListProvider.GetBetByRateId(rateId,out total);
            ViewBag.Total = total;     
            return View(bets);
        }

        

    }
}