using Business.Providers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Common.Models;
using System.ServiceModel;
using System.Data.SqlClient;
using Business.Service;

namespace Tote.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IBetListProvider betListProvider;
        private readonly ICacheService cacheService;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(NavigationController));

        public NavigationController(IBetListProvider rateListProvider, ICacheService cacheService)
        {
            this.betListProvider = rateListProvider;
            this.cacheService = cacheService;
        }

        /*[AllowAnonymous]
        public ActionResult Index()
        {
            IReadOnlyList<Match> rates = betListProvider.GetBetList(1, 1);
            return View(rates[0]);
        }*/
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
            log.Info("Controller: Navigation Action: List");
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
                log.Error(sqlEx.Message+" "+ sqlEx.StackTrace);
                return RedirectToAction("InfoError", "Error");
            }
            catch(CommunicationException commEx)
            {                
                log.Error(commEx.Message + " " + commEx.StackTrace);
                return RedirectToAction("InfoError", "Error");
            }


            return View(bets);
        }
        [AllowAnonymous]
        public ActionResult InfoError()
        {
            return View();
        }
        /*public ActionResult Sports()
        {
            IReadOnlyList<Sport> sports = betListProvider.GetSports();
            if (sports == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(sports);
        }
        [AllowAnonymous]
        public ActionResult Sport()
        {
            Sport sport = betListProvider.GetSport(1);
            if (sport == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(sport);
        }
        */
    }
}