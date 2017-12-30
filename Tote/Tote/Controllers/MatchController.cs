using Business.Providers;
using Business.Service;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Tote.Attribute;
using log4net;
using Common.Logger;

namespace Tote.Controllers
{
    public class MatchController : Controller
    {
        private const string cacheSortKey = "sortKey";
        private const string cacheNavigationKey = "navigateKey";
        private readonly IMatchProvider matchProvider;
        private readonly IBetListProvider betListProvider;
        private readonly ITeamProvider teamProvider;
        private readonly ICacheService cacheService;
        private readonly IUpdateMatchService matchService;
        private readonly ILog log;
        private readonly ILogService<MatchController> logService;

        public MatchController(IBetListProvider betListProvider, IMatchProvider matchProvider, ITeamProvider teamProvider,
            ICacheService cacheService, IUpdateMatchService matchService) 
            :this(betListProvider, matchProvider, teamProvider, cacheService, matchService, new LogService<MatchController>() /*LogManager.GetLogger(typeof(MatchController))*/)
        {

        }

        public MatchController(IBetListProvider betListProvider, IMatchProvider matchProvider, ITeamProvider teamProvider, 
            ICacheService cacheService, IUpdateMatchService matchService, ILogService<MatchController> logService /*ILog log*/)
        {
            if (betListProvider == null || matchProvider == null || teamProvider == null || cacheService == null|| matchProvider==null)
            {
                throw new ArgumentNullException();
            }
            this.betListProvider = betListProvider;
            this.matchProvider = matchProvider;
            this.teamProvider = teamProvider;
            this.cacheService = cacheService;
            this.matchService = matchService;
            if (logService == null)
            {
                this.logService = new LogService<MatchController>();
            }
            else
            {
                this.logService = logService;
            }
        }
        /*
        public MatchController(IBetListProvider betListProvider, IMatchProvider matchProvider, ITeamProvider teamProvider, ICacheService cacheService)
        {
            this.betListProvider = betListProvider;
            this.matchProvider = matchProvider;
            this.teamProvider = teamProvider;
            this.cacheService = cacheService;
            this.log = log4net.LogManager.GetLogger(typeof(MatchController));
        }

        public static MatchController createMatchController(IBetListProvider betListProvider, IMatchProvider matchProvider, ITeamProvider teamProvider, ICacheService cacheService)
        {
            if (betListProvider == null || matchProvider == null|| teamProvider==null|| cacheService==null)
            {
                throw new ArgumentNullException();
            }
            return new MatchController(betListProvider, matchProvider, teamProvider, cacheService);
        }
        */
        [Editor]
        public ActionResult ShowMatches()
        {
            logService.LogInfoMessage("Controller: Match, Action: ShowMatches");
            IReadOnlyList<Match> matches = matchProvider.GetMatchesAll();
            if (matches == null)
            {
                logService.LogError("Controller: Match, Action: ShowMatches Don't GetMatchesAll");
                //log.Error("Controller: Match, Action: ShowMatches Don't GetMatchesAll");
                return RedirectToAction("InfoError", "Error");
            }
            return PartialView(matches);
        }

        [HttpGet]
        [Editor]
        public ActionResult AddMatch()
        {
            logService.LogInfoMessage("Controller: Match, Action: AddMatch");
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            if (sports == null)
            {
                logService.LogError("Controller: Match, Action: AddMatch Don't GetSports");
                //log.Error("Controller: Match, Action: AddMatch Don't GetSports");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sports = sports;
            
            SelectList tournaments = new SelectList(betListProvider.GetTournament(Int32.Parse(sports.First().Value)), "TournamentId", "Name");
            if (tournaments == null)
            {
                logService.LogError("Controller: Match, Action: AddMatch Don't GetTournamentes");
                //log.Error("Controller: Match, Action: AddMatch Don't GetTournamentes");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Tournaments = tournaments;
            SelectList teams = new SelectList(teamProvider.GetTeamsByTournament(Int32.Parse(tournaments.First().Value)), "TeamId", "Name");
            if (teams == null)
            {
                logService.LogError("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                //log.Error("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Teams = teams;

            SelectList teamsGuest = new SelectList(teamProvider.GetTeamsByTournament(Int32.Parse(tournaments.First().Value)), "TeamId", "Name"); ;
            if (teamsGuest == null)
            {
                logService.LogError("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                //log.Error("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.TeamsGuest = teamsGuest;

            return View();
        }

        [Editor]
        public ActionResult TournamentesBySport(int sportId)
        {
            logService.LogInfoMessage("Controller: Match, Action: TournamentesBySport");
            SelectList tournaments = new SelectList(betListProvider.GetTournament(sportId), "TournamentId", "Name");
            if (tournaments == null)
            {
                logService.LogError("Controller: Match, Action: TournamentesBySport Don't GetTournament");
                //log.Error("Controller: Match, Action: TournamentesBySport Don't GetTournament");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Tournaments = tournaments;
            return PartialView();
        }
        [Editor]
        public ActionResult MatchesByTournament(int tournamentId)
        {
            logService.LogInfoMessage("Controller: Match, Action: MatchesByTournament");
            SelectList teams = new SelectList(teamProvider.GetTeamsByTournament(tournamentId), "TeamId", "Name");
            if (teams == null)
            {
                logService.LogError("Controller: Match, Action: MatchesByTournament Don't GetTeamsByTournament");
                //log.Error("Controller: Match, Action: MatchesByTournament Don't GetTeamsByTournament");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Teams = teams;

            SelectList teamsGuest = new SelectList(teamProvider.GetTeamsByTournament(tournamentId), "TeamId", "Name"); ;
            if (teamsGuest == null)
            {
                logService.LogError("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                //log.Error("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.TeamsGuest = teamsGuest;
            return PartialView();
        }

        [HttpPost]
        [Editor]
        public ActionResult AddMatch(Match match)
        {
            bool flag = true;
            bool result = true;
            Result res = new Result { ResultId = 3 };
            match.Result = res;
            match.Score = "0";
            if (match.Teams[0].TeamId != match.Teams[1].TeamId || match.Date > DateTime.Now)
            {
                result = matchService.AddMatch(match);
                flag = false;
            }
            if (!result||flag)
            {
                ModelState.AddModelError("", "You can not add a match with the following parameters");
                logService.LogError("Controller: Match, Action: AddMatch Don't add Match");
                //log.Error("Controller: Match, Action: AddMatch Don't add Match");

                SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
                if (sports == null)
                {
                    logService.LogError("Controller: Match, Action: AddMatch Don't GetSports");
                    //log.Error("Controller: Match, Action: AddMatch Don't GetSports");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Sports = sports;

                SelectList tournaments = new SelectList(betListProvider.GetTournament(match.SportId), "TournamentId", "Name",match.TournamentId);
                if (tournaments == null)
                {
                    logService.LogError("Controller: Match, Action: AddMatch Don't GetTournamentes");
                    //log.Error("Controller: Match, Action: AddMatch Don't GetTournamentes");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Tournaments = tournaments;

                IReadOnlyList<Team> teamsList = teamProvider.GetTeamsByTournament(match.TournamentId);
                Team teamHome = teamsList.Where(t=>t.TeamId==match.Teams[0].TeamId).First();
                SelectList teams = new SelectList(teamsList, "TeamId", "Name", new SelectListItem { Text = teamHome.Name, Value = teamHome.TeamId.ToString() });
                if (teams == null)
                {
                    logService.LogError("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                    //log.Error("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Teams = teams;

                Team teamGuest = teamsList.Where(t => t.TeamId == match.Teams[1].TeamId).First();
                SelectList teamsGuest = new SelectList(teamsList, "TeamId", "Name", new SelectListItem { Text = teamGuest.Name, Value = teamGuest.TeamId.ToString() }); ;
                if (teamsGuest == null)
                {
                    logService.LogError("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                    //log.Error("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.TeamsGuest = teamsGuest;

            }
            else
           // if(ModelState.IsValid)            
            {
                cacheService.DeleteCache(cacheSortKey);
                cacheService.DeleteCache(cacheNavigationKey);
                return RedirectToAction("ShowMatches");
            }

            return View(match);            

        }

        [HttpGet]
        [Editor]
        public ActionResult EditMatch(int id)
        {
            logService.LogInfoMessage("Controller: Match, Action: EditMatch");
            Match match = matchProvider.GetMatchById(id);
            if (match == null)
            {
                logService.LogError("Controller: Match, Action: EditMatch Don't GetMatchById");
                return RedirectToAction("InfoError", "Error");
            }

            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name", match.SportId);
            if (sports == null)
            {
                logService.LogError("Controller: Match, Action: EditMatch Don't GetSports");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sports = sports;
            int selected = match.Tournament.TournamentId;
            SelectList tournaments = new SelectList(betListProvider.GetTournament(match.SportId), "TournamentId", "Name", new SelectListItem { Text = match.Tournament.Name, Value = match.Tournament.TournamentId.ToString() });
            if (tournaments == null)
            {
                logService.LogError("Controller: Match, Action: EditMatch Don't GetTournamentes");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Tournaments = tournaments;

            IReadOnlyList<Team> teamsList = teamProvider.GetTeamsByTournament(match.Tournament.TournamentId);
            Team teamHome = teamsList.Where(t => t.TeamId == match.Teams[0].TeamId).First();
            SelectList teams = new SelectList(teamsList, "TeamId", "Name",teamHome.TeamId );
            if (teams == null)
            {
                logService.LogError("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Teams = teams;

            Team teamGuest = teamsList.Where(t => t.TeamId == match.Teams[1].TeamId).First();
            SelectList teamsGuest = new SelectList(teamsList, "TeamId", "Name", teamGuest.TeamId); ;
            if (teamsGuest == null)
            {
                logService.LogError("Controller: Match, Action: EditMatch Don't GetTeamsAll");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.TeamsGuest = teamsGuest;

            selected = match.Result.ResultId;
            SelectList results = new SelectList(matchProvider.GetResultsAll(),"ResultId","Name", selected);
            if (results == null)
            {
                logService.LogError("Controller: Match, Action: EditMatch Don't GetResultsAll");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Results = results;
            return View(match);
        }

        [HttpPost]
        [Editor]
        public ActionResult EditMatch(Match match)
        {
            bool flag = true;
            bool result = true;
            if (match.Teams[0].TeamId != match.Teams[1].TeamId || match.Date > DateTime.Now)
            {
                result = matchService.UpdateMatch(match);
                flag = false;
            }
            if (!result || flag)
            {
                ModelState.AddModelError("", "You can not update a match with the following parameters");
                logService.LogError("Controller: Match, Action: AddMatch Don't add Match");

                SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
                if (sports == null)
                {
                    logService.LogError("Controller: Match, Action: AddMatch Don't GetSports");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Sports = sports;

                SelectList tournaments = new SelectList(betListProvider.GetTournament(match.SportId), "TournamentId", "Name", match.TournamentId);
                if (tournaments == null)
                {
                    logService.LogError("Controller: Match, Action: AddMatch Don't GetTournamentes");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Tournaments = tournaments;

                IReadOnlyList<Team> teamsList = teamProvider.GetTeamsByTournament(match.TournamentId);
                
                SelectList teams = new SelectList(teamsList, "TeamId", "Name", match.Teams[0].TeamId);
                if (teams == null)
                {
                    logService.LogError("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Teams = teams;

                
                SelectList teamsGuest = new SelectList(teamsList, "TeamId", "Name", match.Teams[1].TeamId); 
                if (teamsGuest == null)
                {
                    logService.LogError("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.TeamsGuest = teamsGuest;
                
                SelectList results = new SelectList(matchProvider.GetResultsAll(), "ResultId", "Name", match.Result.ResultId);
                if (results == null)
                {
                    logService.LogError("Controller: Match, Action: EditMatch Don't GetResultsAll");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Results = results;

            }
            else
            //if (ModelState.IsValid)
            {
                cacheService.DeleteCache(cacheSortKey);
                cacheService.DeleteCache(cacheNavigationKey);
                return RedirectToAction("ShowMatches");
            }

            return View(match);
        }

        [HttpGet]
        [Editor]
        public ActionResult DeleteMatch(int id)
        {
            logService.LogInfoMessage("Controller: Match, Action: DeleteMatch");
            Match match = matchProvider.GetMatchById(id);
            if (match == null)
            {
                logService.LogError("Controller: Match, Action: DeleteMatch Don't Delete Match");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sport = betListProvider.GetSport(match.SportId).Name;

            return View(match);
        }

        [HttpPost]
        [Editor]
        [ActionName("DeleteMatch")]
        public ActionResult Delete(int matchId)
        {
            bool result = matchService.DeleteMatch(matchId);
            if (!result)
            {
                logService.LogError("Controller: Match, Action: DeleteMatch Don't delete Match");
            }
            else
            {
                cacheService.DeleteCache(cacheSortKey);
                cacheService.DeleteCache(cacheNavigationKey);
            }
            return RedirectToAction("ShowMatches");
        }
        [Editor]
        public ActionResult ShowCoefficient(int id)
        {
            logService.LogInfoMessage("Controller: Match, Action: ShowCoefficient");
            IReadOnlyList<Event> events = matchProvider.GetEventByMatch(id);
            if (events == null)
            {
                logService.LogError("Controller: Match, Action: ShowCoefficient Don't Show Coefficient");
                return RedirectToAction("InfoError", "Error");
            }
            
            return View(events);
        }

        [HttpGet]
        [Editor]
        public ActionResult AddEvents()
        {           
            return View();
        }

        [HttpPost]
        [Editor]
        public ActionResult AddEvents(List<Event> item)
        {
            if (ModelState.IsValid)
            {
                bool result = matchService.AddEvent(item.ToArray());
                if (!result)
                {
                    logService.LogError("Controller: Match, Action: EditMatch Don't add Match");
                }
                else
                {
                    cacheService.DeleteCache(cacheSortKey);
                }
                return RedirectToAction("ShowMatches");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        [Editor]
        public ActionResult EditEvent(int id)
        {
            logService.LogInfoMessage("Controller: Match, Action: EditEvent");
            IReadOnlyList<Event> events = matchProvider.GetEventByMatch(id);
            if (events == null)
            {
                logService.LogError("Controller: Match, Action: EditMatch Don't update Match");
                return RedirectToAction("InfoError", "Error");
            }
            return View(events);
        }

        [HttpPost]
        [Editor]
        public ActionResult EditEvent(List<Event> item)
        {            
            if (ModelState.IsValid)
            {
                bool result = matchService.UpdateEvent(item.ToArray());
                if (!result)
                {
                    logService.LogError("Controller: Match, Action: EditMatch Don't update Match");
                }
                return RedirectToAction("ShowMatches");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult DeleteEvent(int id)
        {
            IReadOnlyList<Event> events = matchProvider.GetEventByMatch(id);            

            return View(events);
        }

        [HttpPost]
        [Editor]
        [ActionName("DeleteEvent")]
        public ActionResult DeleteEv(int matchId)
        {
            bool result = matchService.DeleteEvent(matchId);
            if (!result)
            {
                logService.LogError("Controller: Match, Action: DeleteMatch Don't delete Match");
            }
            return RedirectToAction("ShowMatches");
        }


    }
}