using Business.Providers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Common.Models;
using System.ServiceModel;
using System.Data.SqlClient;
using Business.Service;
using log4net;
using Common.Logger;

namespace Tote.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IBetListProvider betListProvider;
        private readonly ICacheService cacheService;
        private readonly ILog log;
        private readonly ILogService<NavigationController> logService;
        //private readonly ILogger logger;

        public NavigationController(IBetListProvider rateListProvider, ICacheService cacheService) 
            :this(rateListProvider, cacheService, new LogService<NavigationController>() /*LogManager.GetLogger(typeof(NavigationController))*/)
        {

        }

        public NavigationController(IBetListProvider rateListProvider, ICacheService cacheService, ILogService<NavigationController> logService  /*ILog log*/)
        {
            if (rateListProvider == null || cacheService == null)
            {
                throw new ArgumentNullException();
            }
            this.betListProvider = rateListProvider;
            this.cacheService = cacheService;
            this.logService = logService;
            /*if (logger == null)
            {
                this.logger = new Logger(typeof(NavigationController));
            }
            else
            {
                this.logger = logger;
            }*/
            /*if (log == null)
            {
                this.log = LogManager.GetLogger(typeof(NavigationController));
            }
            else
            {
                this.log = log;
            }*/
        }
        /*
        public NavigationController(IBetListProvider rateListProvider, ICacheService cacheService)
        {
            this.betListProvider = rateListProvider;
            this.cacheService = cacheService;
        }

        public static NavigationController createMatchController(IBetListProvider rateListProvider, ICacheService cacheService)
        {
            if (rateListProvider == null || cacheService == null)
            {
                throw new ArgumentNullException();
            }
            return new NavigationController(rateListProvider, cacheService);
        }
        */
        [AllowAnonymous]
        public ActionResult ChildTournament(int id = 0)
        {
            IReadOnlyList<Tournament> tournaments = cacheService.GetCache(id);
            if (tournaments == null)
            {
                tournaments = cacheService.InsertCache(id);
            }
            if (tournaments==null)
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
                if(bets==null)
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
            log.Error(ex.Message + " " + ex.StackTrace);
            return RedirectToAction("InfoError", "Error");
        }
        [AllowAnonymous]
        public ActionResult Bet(int id)
        {
            IReadOnlyList<Match> bets = betListProvider.GetMatchesAll();
            if (bets.Count == 0)
            {
                return RedirectToAction("InfoError", "Error");
            }
            Match bet = new Match();
            foreach(Match b in bets)
            {
                if(b.MatchId==id)
                {
                    bet = b;
                    break;
                }
            }
            return View(bet);
        }
        [AllowAnonymous]
        public ActionResult List(int? SportId, int? TournamentId = null)
        {
            logService.LogInfoMessage("Controller: Navigation, Action: List");
            //log.Info("Controller: Navigation, Action: List");
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
                if (bets.Count == 0)
                {
                    return RedirectToAction("InfoError", "Error");
                }
            }
            catch(FaultException<SqlException> sqlEx)
            {
                logService.LogError(sqlEx.Message + " " + sqlEx.StackTrace);
                //log.Error(sqlEx.Message+" "+ sqlEx.StackTrace);
                return RedirectToAction("InfoError", "Error");
            }
            catch(CommunicationException commEx)
            {
                logService.LogError(commEx.Message + " " + commEx.StackTrace);
                //log.Error(commEx.Message + " " + commEx.StackTrace);
                return RedirectToAction("InfoError", "Error");
            }


            return View(bets);
        }
        [AllowAnonymous]
        public ActionResult InfoError()
        {
            return View();
        }
        
    }
}