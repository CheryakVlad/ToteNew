using Business.Providers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tote.Attribute;
using Business.Service;
using Common.Logger;

namespace Tote.Controllers
{
    public class TournamentController : Controller
    {
        private const string tournamentCacheKey = "tournamentKey";

        private readonly ITournamentProvider tournamentProvider;
        private readonly ISportProvider sportProvider;        
        private readonly ICacheService cacheService;
        private readonly IUpdateTournamentService tournamentService;        
        private readonly ILogService<TournamentController> logService;

        public TournamentController(ITournamentProvider tournamentProvider, ICacheService cacheService, 
            IUpdateTournamentService tournamentService, ISportProvider sportProvider) 
            :this(tournamentProvider, cacheService, tournamentService, sportProvider, new LogService<TournamentController>())
        {

        }

        public TournamentController(ITournamentProvider tournamentProvider,ICacheService cacheService, 
            IUpdateTournamentService tournamentService, ISportProvider sportProvider, ILogService<TournamentController> logService)
        {
            if (tournamentProvider == null|| cacheService==null|| tournamentService==null || sportProvider == null)
            {
                throw new ArgumentNullException();
            }            
            this.tournamentProvider = tournamentProvider;
            this.cacheService = cacheService;
            this.tournamentService = tournamentService;
            this.sportProvider = sportProvider;
            if (logService == null)
            {
                this.logService = new LogService<TournamentController>();
            }
            else
            {
                this.logService = logService;
            }
        }
       
        [Editor]
        public ActionResult ShowTournaments()
        {
            logService.LogInfoMessage("Controller: Tournament, Action: ShowTournaments");
            IReadOnlyList<Tournament> tournaments = tournamentProvider.GetTournamentes();
            if (tournaments.Count == 0)
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
            IReadOnlyList<Sport> sportsAll = sportProvider.GetSports();
            if (sportsAll.Count == 0)
            {
                logService.LogError("Controller: Tournament, Action: AddTournament Don't GetSports");
                return RedirectToAction("InfoError", "Error");
            }
            SelectList sports = new SelectList(sportsAll, "SportId", "Name");            
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
                    IReadOnlyList<Sport> sportsAll = sportProvider.GetSports();
                    if (sportsAll.Count == 0)
                    {
                        logService.LogError("Controller: Tournament, Action: AddTournament Don't GetSports");
                        return RedirectToAction("InfoError", "Error");
                    }
                    SelectList sports = new SelectList(sportsAll, "SportId", "Name",tournament.SportId);                    
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
                ModelState.AddModelError("", "You can not add a tournament with the following parameters");
                logService.LogError("Controller: Tournament, Action: AddTournament Don't add Tournament");

                SelectList sports = new SelectList(sportProvider.GetSports(), "SportId", "Name", tournament.SportId);
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

            IReadOnlyList<Sport> sportsAll = sportProvider.GetSports();
            if (sportsAll.Count == 0)
            {
                logService.LogError("Controller: Tournament, Action: AddTournament Don't GetSports");
                return RedirectToAction("InfoError", "Error");
            }
            SelectList sports = new SelectList(sportsAll, "SportId", "Name");
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
                    ModelState.AddModelError("", "You can not edit a tournament with the following parameters");
                    logService.LogError("Controller: Tournament, Action: AddTournament Don't add Tournament");

                    IReadOnlyList<Sport> sportsAll = sportProvider.GetSports();
                    if (sportsAll.Count == 0)
                    {
                        logService.LogError("Controller: Tournament, Action: AddTournament Don't GetSports");
                        return RedirectToAction("InfoError", "Error");
                    }
                    SelectList sports = new SelectList(sportsAll, "SportId", "Name", tournament.SportId);
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
                ModelState.AddModelError("", "You can not edit a tournament with the following parameters");
                logService.LogError("Controller: Tournament, Action: AddTournament Don't add Tournament");

                IReadOnlyList<Sport> sportsAll = sportProvider.GetSports();
                if (sportsAll.Count == 0)
                {
                    logService.LogError("Controller: Tournament, Action: AddTournament Don't GetSports");
                    return RedirectToAction("InfoError", "Error");
                }
                SelectList sports = new SelectList(sportsAll, "SportId", "Name", tournament.SportId);
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