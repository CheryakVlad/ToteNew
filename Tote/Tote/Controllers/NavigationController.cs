using Business.Providers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Common.Models;
using System.ServiceModel;
using System.Data.SqlClient;
using Business.Service;
using Common.Logger;

namespace Tote.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IBetListProvider betListProvider;
        private readonly IMatchProvider matchProvider;
        private readonly ICacheService cacheService;        
        private readonly ILogService<NavigationController> logService;
        

        public NavigationController(IBetListProvider rateListProvider, ICacheService cacheService, IMatchProvider matchProvider) 
            :this(rateListProvider, cacheService, matchProvider, new LogService<NavigationController>())
        {

        }

        public NavigationController(IBetListProvider rateListProvider, ICacheService cacheService, 
            IMatchProvider matchProvider, ILogService<NavigationController> logService)
        {
            if (rateListProvider == null || cacheService == null || matchProvider == null)
            {
                throw new ArgumentNullException();
            }
            this.betListProvider = rateListProvider;
            this.cacheService = cacheService;
            this.matchProvider = matchProvider;
            if (logService == null)
            {
                this.logService = new LogService<NavigationController>();
            }
            else
            {
                this.logService = logService;
            }            
        }
        
        [AllowAnonymous]
        public ActionResult ChildTournament(int id = 0)
        {
            IReadOnlyList<Tournament> tournaments = cacheService.GetCache(id);
            if (tournaments == null)
            {
                tournaments = cacheService.InsertCache(id);
            }
            if (tournaments == null)
            {
                return RedirectToAction("InfoError", "Error");
            }          
            return PartialView(tournaments);
        }
        [AllowAnonymous]
        public ActionResult Menu(int category = 0)
        {
            ViewBag.SelectedCategory = category;
            IReadOnlyList<Sport> sports = cacheService.GetCache();
            if (sports == null)
            {
                sports = cacheService.InsertCache();
            }
            if (sports == null)
            {
                return RedirectToAction("InfoError", "Error");
            }
            return PartialView(sports);
        }
        [AllowAnonymous]
        public ActionResult ListBet(int? SportId, int? TournamentId = null)
        {
            if (SportId == null)
            {
                SportId = 0;
            }
            if (TournamentId == null)
            {
                TournamentId = 0;
            }
            IReadOnlyList<Match> bets = new List<Match>();
            try
            {
                bets = betListProvider.GetBetList(SportId, TournamentId);
                if(bets == null)
                {
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

            return PartialView(bets);
        }
        [AllowAnonymous]
        public ActionResult LogAndRedirect(Exception ex)
        {
            logService.LogError(ex.Message + " " + ex.StackTrace);
            return RedirectToAction("InfoError", "Error");
        }
        [AllowAnonymous]
        public ActionResult Bet(int id)
        {
            logService.LogInfoMessage("Controller: Navigation, Action: Bet");
            Match match = matchProvider.GetMatchWithEvents(id);
            if(match == null)
            {
                return RedirectToAction("InfoError", "Error");
            }            
            return View(match);
        }
        [AllowAnonymous]
        public ActionResult List(int? SportId, int? TournamentId = null)
        {
            logService.LogInfoMessage("Controller: Navigation, Action: List");            
            int sportId=0, tournamentId=0;
            if (SportId!=null)
            {
                sportId = 0;
            }
            if (TournamentId != null)
            {
                tournamentId = 0;
            }
            IReadOnlyList<Match> bets = new List<Match>();
            try
            {
                bets = cacheService.GetCache(sportId, tournamentId);
                if (bets == null)
                {
                    bets = cacheService.InsertCache(sportId, tournamentId);
                }
                if (bets == null)
                {
                    return RedirectToAction("InfoError", "Error");
                }
            }
            catch(FaultException<SqlException> sqlEx)
            {
                logService.LogError(sqlEx.Message + " " + sqlEx.StackTrace);                
                return RedirectToAction("InfoError", "Error");
            }
            catch(CommunicationException commEx)
            {
                logService.LogError(commEx.Message + " " + commEx.StackTrace);                
                return RedirectToAction("InfoError", "Error");
            }


            return View(bets);
        }
                
    }
}