using Business.Providers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Common.Models;
using System.ServiceModel;
using System.Data.SqlClient;

namespace Tote.Controllers
{
    public class NavigationController : Controller
    {
        private IBetListProvider betListProvider;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(NavigationController));

        public NavigationController(IBetListProvider rateListProvider)
        {
            this.betListProvider = rateListProvider;
        }

        
        public ActionResult Index()
        {
            IReadOnlyList<Match> rates = betListProvider.GetBetList(1, 1);
            return View(rates[0]);
        }

        public ActionResult ChildTournament(int id = 0)
        {
            IReadOnlyList<Tournament> tournaments = betListProvider.GetTournament(id);  
            if(tournaments==null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }          
            return PartialView(tournaments);
        }

        public ActionResult Menu(int category = 0)
        {
            ViewBag.SelectedCategory = category;
            IReadOnlyList<Sport> sports = betListProvider.GetSports();
            if (sports == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return PartialView(sports);
        }

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

        public ActionResult Bet(int id)
        {
            IReadOnlyList<Match> bets = betListProvider.GetMatchesAll();
            if (bets.Count == 0)
            {
                return RedirectToAction("InfoError", "Navigation");
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

        public ActionResult List(int? SportId, int? TournamentId = null)
        {
            log.Info("Controller: Navigation Action: List");
            if (SportId==null)
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
                if (bets.Count == 0)
                {
                    return RedirectToAction("InfoError", "Navigation");
                }
            }
            catch(FaultException<SqlException> sqlEx)
            {
                log.Error(sqlEx.Message+" "+ sqlEx.StackTrace);
                return RedirectToAction("InfoError", "Navigation");
            }
            catch(CommunicationException commEx)
            {
                log.Error(commEx.Message + " " + commEx.StackTrace);
                return RedirectToAction("InfoError","Navigation");
            }


            return View(bets);
        }

        public ActionResult InfoError()
        {
            return View();
        }
        public ActionResult Sports()
        {
            IReadOnlyList<Sport> sports = betListProvider.GetSports();
            if (sports == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(sports);
        }

        public ActionResult Sport()
        {
            Sport sport = betListProvider.GetSport(1);
            if (sport == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(sport);
        }

    }
}