using Business.Providers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tote.Attribute;
using log4net;
using Business.Service;
using Common.Logger;

namespace Tote.Controllers
{
    public class TournamentController : Controller
    {
        private const string tournamentCacheKey = "tournamentKey";

        private readonly ITournamentProvider tournamentProvider;
        private readonly IBetListProvider betListProvider;
        private readonly ICacheService cacheService;
        private readonly IUpdateTournamentService tournamentService;
        private readonly ILog log;
        private readonly ILogService<TournamentController> logService;

        public TournamentController(IBetListProvider betListProvider, ITournamentProvider tournamentProvider,
            ICacheService cacheService, IUpdateTournamentService tournamentService) 
            :this(betListProvider, tournamentProvider, cacheService, tournamentService, new LogService<TournamentController>())
        {

        }

        public TournamentController(IBetListProvider betListProvider, ITournamentProvider tournamentProvider,
            ICacheService cacheService, IUpdateTournamentService tournamentService, ILogService<TournamentController> logService)
        {
            if (betListProvider == null || tournamentProvider == null|| cacheService==null|| tournamentService==null)
            {
                throw new ArgumentNullException();
            }
            this.betListProvider = betListProvider;
            this.tournamentProvider = tournamentProvider;
            this.cacheService = cacheService;
            this.tournamentService = tournamentService;
            if (logService == null)
            {
                this.logService = new LogService<TournamentController>();
            }
            else
            {
                this.logService = logService;
            }
        }
        /*
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
        */
        [Editor]
        public ActionResult ShowTournaments()
        {
            logService.LogInfoMessage("Controller: Tournament, Action: ShowTournaments");
            IReadOnlyList<Tournament> tournaments = betListProvider.GetTournamentes();
            if (tournaments == null)
            {
                logService.LogError("Controller: Tournament, Action: ShowTournaments Don't GetTournamentes");
                return RedirectToAction("InfoError", "Error");
            }
            return PartialView(tournaments);
        }
        [HttpGet]
        [Editor]
        public ActionResult AddTournament()
        {
            logService.LogInfoMessage("Controller: Tournament, Action: AddTournament");
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            if (sports == null)
            {
                logService.LogError("Controller: Tournament, Action: AddTournament Don't GetSports");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sports = sports;
            return View();
        }

        [HttpPost]
        [Editor]
        public ActionResult AddTournament(Tournament tournament)
        {
            bool result = true;       
            if (ModelState.IsValid)
            {
                result = tournamentService.AddTournament(tournament);
                if (!result)
                {                    
                    ModelState.AddModelError("", "You can not add a tournament with the following parameters");
                    logService.LogError("Controller: Tournament, Action: AddTournament Don't add Tournament");

                    SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name",tournament.SportId);
                    if (sports == null)
                    {
                        logService.LogError("Controller: Tournament, Action: AddTournament Don't GetSports");
                        return RedirectToAction("InfoError", "Error");
                    }
                    ViewBag.Sports = sports;

                    return View(tournament);                    
                }
                else
                {
                    cacheService.DeleteCache(tournamentCacheKey);
                }
                return RedirectToAction("ShowTournaments");
            }
            else
            {
                SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name", tournament.SportId);
                if (sports == null)
                {
                    logService.LogError("Controller: Tournament, Action: AddTournament Don't GetSports");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Sports = sports;

                return View(tournament);
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult EditTournament(int id)
        {
            logService.LogInfoMessage("Controller: Tournament, Action: EditTournament");
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            if (sports == null)
            {
                logService.LogError("Controller: Tournament, Action: EditTournament Don't GetSports");
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
                bool result = tournamentService.UpdateTournament(tournament);
                if (!result)
                {
                    ModelState.AddModelError("", "You can not add a tournament with the following parameters");
                    logService.LogError("Controller: Tournament, Action: AddTournament Don't add Tournament");

                    SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name", tournament.SportId);
                    if (sports == null)
                    {
                        logService.LogError("Controller: Tournament, Action: AddTournament Don't GetSports");
                        return RedirectToAction("InfoError", "Error");
                    }
                    ViewBag.Sports = sports;

                    return View(tournament);
                }
                else
                {
                    cacheService.DeleteCache(tournamentCacheKey);
                }
                return RedirectToAction("ShowTournaments");
            }
            else
            {
                SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name", tournament.SportId);
                if (sports == null)
                {
                    logService.LogError("Controller: Tournament, Action: AddTournament Don't GetSports");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Sports = sports;

                return View(tournament);
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult DeleteTournament(int id)
        {
            logService.LogInfoMessage("Controller: Tournament, Action: DeleteTournament");
            Tournament tournament = tournamentProvider.GetTournamentById(id);
            if (tournament == null)
            {
                logService.LogError("Controller: Tournament, Action: DeleteTournament Don't GetTournamentById");
                return RedirectToAction("InfoError", "Error");
            }
            return View(tournament);
        }

        [HttpPost]
        [Editor]
        [ActionName("DeleteTournament")]
        public ActionResult Delete(int tournamentId)
        {
            bool result = tournamentService.DeleteTournament(tournamentId);
            if (!result)
            {
                logService.LogError("Controller: Tournament, Action: DeleteTournament Don't delete Tournament");
            }
            else
            {
                cacheService.DeleteCache(tournamentCacheKey);
            }
            return RedirectToAction("ShowTournaments");
        }
    }
}