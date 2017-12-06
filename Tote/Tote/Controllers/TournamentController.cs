using Business.Providers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tote.Controllers
{
    public class TournamentController : Controller
    {
        private ITournamentProvider tournamentProvider;
        private IBetListProvider betListProvider;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TournamentController));

        public TournamentController(IBetListProvider betListProvider, ITournamentProvider tournamentProvider)
        {
            this.betListProvider = betListProvider;
            this.tournamentProvider = tournamentProvider;
        }
        public ActionResult ShowTournaments()
        {
            IReadOnlyList<Tournament> sports = betListProvider.GetTournamentes();
            if (sports == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return PartialView(sports);
        }
        [HttpGet]
        public ActionResult AddTournament()
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            return View();
        }

        [HttpPost]
        public ActionResult AddTournament(Tournament tournament)
        {
            
            bool result = tournamentProvider.AddTournament(tournament);
            if (!result)
            {
                log.Error("Controller: Tournament, Action: AddTournament Don't add Tournament");
            }

            return RedirectToAction("ShowTournaments");
        }

        [HttpGet]
        public ActionResult EditTournament(int id)
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            Tournament tournament = tournamentProvider.GetTournamentById(id);

            return View(tournament);
        }
        [HttpPost]
        public ActionResult EditTournament(Tournament tournament)
        {
            bool result = tournamentProvider.UpdateTournament(tournament);
            if (!result)
            {
                log.Error("Controller: Tournament, Action: EditTournament Don't update Tournament");
            }
            return RedirectToAction("ShowTournaments");
        }

        [HttpGet]
        public ActionResult DeleteTournament(int id)
        {
            Tournament tournament = tournamentProvider.GetTournamentById(id);
            return View(tournament);
        }

        [HttpPost]
        [ActionName("DeleteTournament")]
        public ActionResult Delete(int tournamentId)
        {
            bool result = tournamentProvider.DeleteTournament(tournamentId);
            if (!result)
            {
                log.Error("Controller: Tournament, Action: DeleteTournament Don't delete Tournament");
            }
            return RedirectToAction("ShowTournaments");
        }
    }
}