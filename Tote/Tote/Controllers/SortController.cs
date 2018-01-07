using Business.Principal;
using Business.Providers;
using Business.Service;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Web.Mvc;
using Tote.Attribute;
using Common.Logger;

namespace Tote.Controllers
{
    public class SortController : Controller
    {
        private const string cacheKey = "sortKey";
        private readonly IBetListProvider betListProvider;
        private readonly IMatchProvider matchProvider;
        private readonly ISportProvider sportProvider;
        private readonly IUserProvider userProvider;
        private readonly ICacheService cacheService;
        private readonly IUpdateBetListService betListService;        
        private readonly ILogService<SortController> logService;

        public SortController(IBetListProvider rateListProvider, IMatchProvider matchProvider, IUserProvider userProvider,
            ICacheService cacheService, IUpdateBetListService betListService, ISportProvider sportProvider) 
            :this(rateListProvider, matchProvider, userProvider, cacheService, betListService, sportProvider, new LogService<SortController>())
        {

        }

        public SortController(IBetListProvider rateListProvider, IMatchProvider matchProvider, IUserProvider userProvider,
            ICacheService cacheService, IUpdateBetListService betListService, ISportProvider sportProvider, ILogService<SortController> logService)
        {
            if (rateListProvider == null || cacheService == null || matchProvider == null || 
                userProvider == null|| betListService==null || sportProvider == null)
            {
                throw new ArgumentNullException();
            }
            this.betListProvider = rateListProvider;
            this.matchProvider = matchProvider;
            this.userProvider = userProvider;
            this.cacheService = cacheService;
            this.betListService = betListService;
            this.sportProvider = sportProvider;
            if (logService == null)
            {
                this.logService = new LogService<SortController>();
            }
            else
            {
                this.logService = logService;
            }
        }
        
        [AllowAnonymous]
        public ActionResult Sorting()
        {
            logService.LogInfoMessage("Controller: Sort, Action: Sorting");
            SelectList sports = new SelectList(sportProvider.GetSports(), "SportId", "Name");
            if (sports == null)
            {
                logService.LogError("Controller: Sort, Action: Sorting Don't GetSports");
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
        

        [HttpGet]
        public ActionResult Match(int sportId, string dateMatch, int status)
        {            
            string cache = sportId.ToString() + dateMatch + status.ToString();
            IReadOnlyList<Match> matches = null; 
            try
            {
                matches = cacheService.GetCache(sportId, dateMatch, status);            
            
                if (matches.Count == 0)
                {
                    matches = cacheService.InsertCache(sportId, dateMatch, status);
                }
                
                if (matches.Count == 0)
                {
                    logService.LogError("Controller: Sort, Action: Match Don't GetMatches");
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
            logService.LogError(ex.Message + " " + ex.StackTrace);
            return RedirectToAction("InfoError", "Error");
        }

       
        [AllowAnonymous]
        public JsonResult AjaxMethod(int sportId, string dateMatch, int status)
        {            
            logService.LogInfoMessage("Controller: Sort, Action: AjaxMethod");
            string cache = sportId.ToString() + dateMatch + status.ToString();
            IReadOnlyList<Match> matches = null;
            try
            {
                matches = cacheService.GetCache(sportId, dateMatch, status);

                if (matches == null)
                {
                    matches = cacheService.InsertCache(sportId, dateMatch, status);
                }                              
                if (matches.Count == 0)
                {
                    logService.LogError("Controller: Sort, Action: Match Don't GetMatches");
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
            logService.LogInfoMessage("Controller: Sort, Action: ShowCoefficient");
            ViewBag.Match = matchId;
            Match match = matchProvider.GetMatchById(matchId);
            if (match == null)
            {
                logService.LogError("Controller: Sort, Action: ShowCoefficient Don't GetMatchById");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.MatchDate = match.Date;
            IReadOnlyList<Event> events = matchProvider.GetEventByMatch(matchId);
            if (events.Count == 0)
            {
                logService.LogError("Controller: Sort, Action: ShowCoefficient Don't GetEventByMatch");
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
            bool result=betListService.AddBasket(matchId, eventId, userId);
            if (result == false)
            {
                logService.LogError("Controller: Sort, Action: ShowCoefficient Don't AddBasket");                
            }
            return RedirectToAction("Sorting");
        }

        [HttpGet]
        [User]
        public ActionResult ShowBasket()
        {
            logService.LogInfoMessage("Controller: Sort, Action: ShowBasket User:"+ (HttpContext.User as UserPrincipal).Login);
            double total = 1;
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            IReadOnlyList<Basket> baskets = betListProvider.GetBasketByUser(userId, out total);            
            ViewBag.Total = total;
            ViewBag.MakeRate = baskets.Count > 0 ? true : false;
            
            return View(baskets);
        }

        [HttpGet]
        [User]
        public ActionResult DeleteBasket(int basketId)
        {
            logService.LogInfoMessage("Controller: Sort, Action: DeleteBasket User:" + (HttpContext.User as UserPrincipal).Login);
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            Basket basket = betListProvider.GetBasketById(basketId, userId);
            if (basket == null)
            {
                logService.LogError("Controller: Sort, Action: DeleteBasket Don't Delete Basket");
                return RedirectToAction("InfoError", "Error");
            }
            return View(basket);
        }

        [HttpPost]
        [User]
        [ActionName("DeleteBasket")]
        public ActionResult Delete(int basketId)
        {            
            bool delete = betListService.DeleteBasket(basketId);
            if (!delete)
            {
                logService.LogError("Controller: Sort, Action: DeleteBasket Don't delete BasketItem");
            }
            return RedirectToAction("ShowBasket");
        }

        [HttpGet]
        [User]
        public ActionResult MakeRate()
        {
            logService.LogInfoMessage("Controller: Sort, Action: MakeRate User:" + (HttpContext.User as UserPrincipal).Login);
            int userId = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = (HttpContext.User as UserPrincipal).UserId;
            }
            User user = userProvider.GetUser(userId);
            if (user == null)
            {
                logService.LogError("Controller: Sort, Action: MakeRate Don't GetUser");
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
            
            betListService.AddBets(amount, userId);
            
            return RedirectToAction("ShowUserProfile","User");
        }

        [HttpGet]
        [User]
        public ActionResult ShowBetsByRate(int rateId)
        {
            logService.LogInfoMessage("Controller: Sort, Action: ShowBetsByRate User:" + (HttpContext.User as UserPrincipal).Login);
            double total = 1;
            IReadOnlyList<Bet> bets = betListProvider.GetBetByRateId(rateId,out total);
            if (bets.Count == 0 || total == 0)
            {
                logService.LogError("Controller: Sort, Action: ShowBetsByRate Don't GetBetByRateId");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Total = total;     
            return View(bets);
        }

        

    }
}