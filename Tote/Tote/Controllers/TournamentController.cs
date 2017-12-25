using Business.Providers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tote.Attribute;

namespace Tote.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentProvider tournamentProvider;
        private readonly IBetListProvider betListProvider;
        private readonly log4net.ILog log;

        public TournamentController(IBetListProvider betListProvider, ITournamentProvider tournamentProvider)
        {
            this.betListProvider = betListProvider;
            this.tournamentProvider = tournamentProvider;
            this.log = log4net.LogManager.GetLogger(typeof(TournamentController));
        }

        public static TournamentController createMatchController(IBetListProvider betListProvider, ITournamentProvider tournamentProvider)
        {
            if (betListProvider == null || tournamentProvider == null)
            {
                throw new ArgumentNullException();
            }
            return new TournamentController(betListProvider, tournamentProvider);
        }

        [Editor]
        public ActionResult ShowTournaments()
        {
            IReadOnlyList<Tournament> tournaments = betListProvider.GetTournamentes();
            if (tournaments == null)
            {
                log.Error("Controller: Tournament, Action: ShowTournaments Don't GetTournamentes");
                return RedirectToAction("InfoError", "Error");
            }
            return PartialView(tournaments);
        }
        [HttpGet]
        [Editor]
        public ActionResult AddTournament()
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            if (sports == null)
            {
                log.Error("Controller: Tournament, Action: AddTournament Don't GetSports");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sports = sports;
            return View();
        }

        [HttpPost]
        [Editor]
        public ActionResult AddTournament(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                bool result = tournamentProvider.AddTournament(tournament);
                if (!result)
                {
                    log.Error("Controller: Tournament, Action: AddTournament Don't add Tournament");
                }

                return RedirectToAction("ShowTournaments");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult EditTournament(int id)
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            if (sports == null)
            {
                log.Error("Controller: Tournament, Action: EditTournament Don't GetSports");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sports = sports;
            Tournament tournament = tournamentProvider.GetTournamentById(id);

            return View(tournament);
        }

        [HttpPost]
        [Editor]
        public ActionResult EditTournament(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                bool result = tournamentProvider.UpdateTournament(tournament);
                if (!result)
                {
                    log.Error("Controller: Tournament, Action: EditTournament Don't update Tournament");
                }
                return RedirectToAction("ShowTournaments");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult DeleteTournament(int id)
        {
            Tournament tournament = tournamentProvider.GetTournamentById(id);
            if (tournament == null)
            {
                log.Error("Controller: Tournament, Action: DeleteTournament Don't GetTournamentById");
                return RedirectToAction("InfoError", "Error");
            }
            return View(tournament);
        }

        [HttpPost]
        [Editor]
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