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
        [AllowAnonymous]
        public ActionResult Sorting()
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            if (sports == null)
            {
                log.Error("Controller: Sort, Action: Sorting Don't GetSports");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sports = sports;
            string[] statuses = new string[] { "Past Events", "Current Events", "Future Events" };
            SelectList status = new SelectList(statuses);
            ViewBag.Statuses = status;

            IReadOnlyList<Match> matches = cacheService.GetCache(0, "", 0);
            if (matches == null)
            {
                matches = cacheService.InsertCache(0, "", 0);               
            }
            
            if (matches.Count == 0)
            {
                return RedirectToAction("InfoError", "Error");
            }
            return View(matches);
            
        }
        /*[HttpGet]
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
            
        }*/

        [HttpGet]
        public ActionResult Match(int sportId, string dateMatch, int status)
        {            
            string cache = sportId.ToString() + dateMatch + status.ToString();
            IReadOnlyList<Match> matches = null; 
            try
            {
                matches = cacheService.GetCache(sportId, dateMatch, status);            
            
                if (matches == null)
                {
                    matches = cacheService.InsertCache(sportId, dateMatch, status);
                }
                
                if (matches == null)
                {
                    log.Error("Controller: Sort, Action: Match Don't GetMatches");
                    return RedirectToAction("InfoError", "Error");
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
        [AllowAnonymous]
        public ActionResult LogAndRedirect(Exception ex)
        {
            log.Error(ex.Message + " " + ex.StackTrace);
            return RedirectToAction("InfoError", "Error");
        }

       
        [AllowAnonymous]
        public JsonResult AjaxMethod(int sportId, string dateMatch, int status)
        {
            /*IReadOnlyList<Match> matches = null;
            try
            {
                matches = cacheService.GetCache(sportId, dateMatch, status);

                if (matches == null)
                {
                    matches = cacheService.InsertCache(sportId, dateMatch, status);
                }

                if (matches == null)
                {
                    log.Error("Controller: Sort, Action: Match Don't GetSports");
                    return RedirectToAction("InfoError", "Error");
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

            return PartialView(matches);*/

            string cache = sportId.ToString() + dateMatch + status.ToString();
            IReadOnlyList<Match> matches = null;// HttpRuntime.Cache.Get(cache) as IReadOnlyList<Match>;
            try
            {
                matches = cacheService.GetCache(sportId, dateMatch, status);

                if (matches == null)
                {
                    matches = cacheService.InsertCache(sportId, dateMatch, status);
                }                              
                if (matches == null)
                {
                    log.Error("Controller: Sort, Action: Match Don't GetMatches");
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
        [AllowAnonymous]
        public ActionResult ShowCoefficient(int matchId)
        {
            ViewBag.Match = matchId;
            Match match = matchProvider.GetMatchById(matchId);
            if (match == null)
            {
                log.Error("Controller: Sort, Action: ShowCoefficient Don't GetMatchById");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.MatchDate = match.Date;
            IReadOnlyList<Event> events = matchProvider.GetEventByMatch(matchId);
            if (events == null)
            {
                log.Error("Controller: Sort, Action: ShowCoefficient Don't GetEventByMatch");
                return RedirectToAction("InfoError", "Error");
            }

            return View(events);
        }

        [HttpPost]
        [User]
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
        [User]
        public ActionResult ShowBasket()
        {
            double total = 1;
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            IReadOnlyList<Basket> baskets = betListProvider.GetBasketByUser(userId,out total);
            if (baskets == null||total==0)
            {
                log.Error("Controller: Sort, Action: ShowBasket Don't GetBasketByUser");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Total = total;
            return View(baskets);
        }

        [HttpGet]
        [User]
        public ActionResult DeleteBasket(int basketId)
        {
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            Basket basket = betListProvider.GetBasketById(basketId, userId);
            if (basket == null)
            {
                log.Error("Controller: Sort, Action: DeleteBasket Don't Delete Basket");
                return RedirectToAction("InfoError", "Error");
            }
            return View(basket);
        }

        [HttpPost]
        [User]
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
        [User]
        public ActionResult MakeRate()
        {
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            User user = userProvider.GetUser(userId);
            if (user == null)
            {
                log.Error("Controller: Sort, Action: MakeRate Don't GetUser");
                return RedirectToAction("InfoError", "Error");
            }
            return View(user);
        }

        [HttpPost]
        [User]
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
            //debit
            /*User user = userProvider.GetUser(userId);
            user.Money -= amount;
            userProvider.UpdateUser(user);*/
            int rateId = betListProvider.AddRate(rate);
            if (rateId <= 0)
            {
                log.Error("Controller: Sort, Action: MakeRate Don't AddRate");
                return RedirectToAction("InfoError", "Error");
            }
            double total = 1;
            IReadOnlyList<Basket> baskets = betListProvider.GetBasketByUser(userId, out total);
            if (baskets == null||total==0)
            {
                log.Error("Controller: Sort, Action: MakeRate Don't GetBasketByUser");
                return RedirectToAction("InfoError", "Error");
            }
            foreach (Basket basket in baskets)
            {
                Bet bet = new Bet()
                {
                    RateId=rateId,
                    MatchId=basket.MatchId,
                    Event=new Event { EventId=basket.EventId}
                };
                betListProvider.AddBet(bet, basket.BasketId);
            }
            return RedirectToAction("ShowUserProfile","User");
        }

        [HttpGet]
        [User]
        public ActionResult ShowBetsByRate(int rateId)
        {
            double total = 1;
            IReadOnlyList<Bet> bets = betListProvider.GetBetByRateId(rateId,out total);
            if (bets == null || total == 0)
            {
                log.Error("Controller: Sort, Action: ShowBetsByRate Don't GetBetByRateId");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Total = total;     
            return View(bets);
        }

        

    }
}