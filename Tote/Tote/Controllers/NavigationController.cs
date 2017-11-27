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
        private IRateListProvider rateListProvider;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(NavigationController));

        public NavigationController(IRateListProvider rateListProvider)
        {
            this.rateListProvider = rateListProvider;
        }

        // GET: Navigation
        public ActionResult Index()
        {
            IList<Bet> rates = rateListProvider.GetRateList(1, 1);
            return View(rates[0]);
        }

        public PartialViewResult ChildTournament(int id = 0)
        {
            IList<Tournament> tournaments = rateListProvider.GetTournament(id);            
            return PartialView(tournaments);
        }

        public PartialViewResult Menu(int category = 0)
        {
            ViewBag.SelectedCategory = category;
            IList<Sport> sports = rateListProvider.GetSports();
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
                bets = rateListProvider.GetRateList(SportId, TournamentId);
            }
            catch (FaultException ex)
            {
                log.Error(ex.Message + " " + ex.StackTrace);
                return RedirectToAction("InfoError", "Navigation");
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message + " " + ex.StackTrace);
                return RedirectToAction("InfoError", "Navigation");
            }
            return PartialView(bets);
        }

        public ActionResult Bet(int id)
        {
            IList<Bet> rates = rateListProvider.GetRateAll();
            Bet bet = new Bet();
            foreach(Bet r in rates)
            {
                if(r.BetId==id)
                {
                    bet = r;
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
                rates = rateListProvider.GetRateList(SportId, TournamentId);
            }
            catch(FaultException ex)
            {
                log.Error(ex.Message+" "+ex.StackTrace);
                return RedirectToAction("InfoError", "Navigation");
            }
            catch(SqlException ex)
            {
                log.Error(ex.Message + " " + ex.StackTrace);
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
            IList<Sport> sports = rateListProvider.GetSports();
            return View(sports);
        }

        public ActionResult Sport()
        {
            Sport sport = rateListProvider.GetSport(1);
            return View(sport);
        }

    }
}