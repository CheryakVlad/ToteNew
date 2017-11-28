using Business.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        // GET: Navigation
        public ActionResult Index()
        {
            IList<Bet> rates = betListProvider.GetBetList(1, 1);
            return View(rates[0]);
        }

        public PartialViewResult ChildTournament(int id = 0)
        {
            IList<Tournament> tournaments = betListProvider.GetTournament(id);            
            return PartialView(tournaments);
        }

        public PartialViewResult Menu(int category = 0)
        {
            ViewBag.SelectedCategory = category;
            IList<Sport> sports = betListProvider.GetSports();
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
            IList<Bet> bets = new List<Bet>();
            try
            {
                bets = betListProvider.GetBetList(SportId, TournamentId);
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
            IList<Bet> bets = betListProvider.GetBetAll();
            Bet bet = new Bet();
            foreach(Bet b in bets)
            {
                if(b.BetId==id)
                {
                    bet = b;
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
            IList<Bet> rates = new List<Bet>();
            try
            {
                rates = betListProvider.GetBetList(SportId, TournamentId);
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


            return View(rates);
        }

        public ActionResult InfoError()
        {
            return View();
        }
        public ActionResult Sports()
        {
            IList<Sport> sports = betListProvider.GetSports();
            return View(sports);
        }

        public ActionResult Sport()
        {
            Sport sport = betListProvider.GetSport(1);
            return View(sport);
        }

    }
}