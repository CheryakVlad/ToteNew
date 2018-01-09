using Business.Providers;
using Business.Service;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Tote.Attribute;
using Common.Logger;
using Common.Pagination;

namespace Tote.Controllers
{
    public class MatchController : Controller
    {
        private const string cacheSortKey = "sortKey";
        private const string cacheNavigationKey = "navigateKey";
        private const int maxRows = 10;
        private readonly IMatchProvider matchProvider;        
        private readonly ITournamentProvider tournamentProvider;
        private readonly ISportProvider sportProvider;
        private readonly ITeamProvider teamProvider;
        private readonly ICacheService cacheService;
        private readonly IUpdateMatchService matchService;
        private readonly ILogService<MatchController> logService;
        private readonly IMatchPaging matchPaging;

        public MatchController(IMatchProvider matchProvider, ITeamProvider teamProvider,
            ICacheService cacheService, IUpdateMatchService matchService, 
            IMatchPaging matchPaging, ITournamentProvider tournamentProvider, ISportProvider sportProvider) 
            :this(matchProvider, teamProvider, cacheService, matchService, matchPaging, tournamentProvider, sportProvider, new LogService<MatchController>())
        {

        }

        public MatchController(IMatchProvider matchProvider, ITeamProvider teamProvider, 
            ICacheService cacheService, IUpdateMatchService matchService, 
            IMatchPaging matchPaging, ITournamentProvider tournamentProvider, ISportProvider sportProvider, ILogService<MatchController> logService)
        {
            if (matchProvider == null || teamProvider == null ||
                cacheService == null|| matchProvider==null || matchPaging==null || tournamentProvider == null || sportProvider == null)
            {
                throw new ArgumentNullException();
            }            
            this.matchProvider = matchProvider;
            this.teamProvider = teamProvider;
            this.cacheService = cacheService;
            this.matchService = matchService;
            this.matchPaging = matchPaging;
            this.tournamentProvider = tournamentProvider;
            this.sportProvider = sportProvider;
            if (logService == null)
            {
                this.logService = new LogService<MatchController>();
            }
            else
            {
                this.logService = logService;
            }
        }
        
        [Editor]
        [HttpGet]
        public ActionResult ShowMatches()
        {
            logService.LogInfoMessage("Controller: Match, Action: ShowMatches");
            IReadOnlyList<Match> matches = matchProvider.GetMatchesAll();
            if (matches == null)
            {
                logService.LogError("Controller: Match, Action: ShowMatches Don't GetMatchesAll");                
                return RedirectToAction("InfoError", "Error");
            }
            matchPaging.SetMatches(matches);
            IReadOnlyList<Match> matchesPaging = matchPaging.GetMatchesPaging(1, maxRows);
            ViewBag.PageCount = matchPaging.GetPageCount();
            ViewBag.CurrentPageIndex = 1;
            return PartialView(matchesPaging);            
        }

        [Editor]
        [HttpPost]
        public ActionResult ShowMatches(int currentPageIndex)
        {                        
            logService.LogInfoMessage("Controller: Match, Action: ShowMatches");
            IReadOnlyList<Match> matches = matchProvider.GetMatchesAll();
            if (matches == null)
            {
                logService.LogError("Controller: Match, Action: ShowMatches Don't GetMatchesAll");
                return RedirectToAction("InfoError", "Error");
            }
            matchPaging.SetMatches(matches);
            IReadOnlyList<Match> matchesPaging = matchPaging.GetMatchesPaging(currentPageIndex, maxRows);
            ViewBag.PageCount = matchPaging.GetPageCount();
            ViewBag.CurrentPageIndex = currentPageIndex;
            return PartialView(matchesPaging);
        }


        private SelectList GetSports(int sport = 1)
        {
            IReadOnlyList<Sport> sportsAll = sportProvider.GetSports();
            if (sportsAll.Count == 0)
            {
                logService.LogError("Controller: Match, Don't GetSports");
                return null;
            }
            SelectList sports = new SelectList(sportsAll, "SportId", "Name", sport);

            return sports;
        }

        private SelectList GetTournaments(int sport = 1, int tournament = 1)
        {
            IReadOnlyList<Tournament> tournamentsAll = tournamentProvider.GetTournament(sport);
            if (tournamentsAll.Count == 0)
            {
                logService.LogError("Controller: Match, Don't GetTournament");
                return null;
            }
            SelectList tournaments = new SelectList(tournamentsAll, "TournamentId", "Name", tournament);

            return tournaments;
        }
        private SelectList GetTeams(int tournament = 1, int team = 1)
        {
            IReadOnlyList<Team> teamsAll = teamProvider.GetTeamsByTournament(tournament);
            if (teamsAll.Count == 0)
            {
                logService.LogError("Controller: Match, Don't GetTeamsByTournament");
                return null;
            }
            SelectList teams = new SelectList(teamsAll, "TeamId", "Name", team);
            return teams;
        }

        private SelectList GetResults(int result = 1)
        {
            IReadOnlyList<Result> resultsAll = matchProvider.GetResultsAll();
            if (resultsAll.Count == 0)
            {
                logService.LogError("Controller: Match, Don't GetResultsAll");
                return null;
            }
            SelectList results = new SelectList(resultsAll, "ResultId", "Name", result);
            return results;
        }

        [HttpGet]
        [Editor]
        public ActionResult AddMatch()
        {
            logService.LogInfoMessage("Controller: Match, Action: AddMatch");

            SelectList sports = GetSports();
            if (sports == null)
            {
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sports = sports;

            SelectList tournaments = GetTournaments(Int32.Parse(sports.First().Value));
            if (tournaments == null)
            {
                return RedirectToAction("InfoDB", "Error");
            }
            ViewBag.Tournaments = tournaments;

            SelectList teams = GetTeams(Int32.Parse(tournaments.First().Value));
            if (teams == null)
            {
                return RedirectToAction("InfoDB", "Error");
            }
            ViewBag.Teams = teams;
            ViewBag.TeamsGuest = teams;

            return View();
        }

        [Editor]
        public ActionResult TournamentesBySport(int sportId)
        {
            logService.LogInfoMessage("Controller: Match, Action: TournamentesBySport");
            SelectList tournaments = new SelectList(tournamentProvider.GetTournament(sportId), "TournamentId", "Name");            
            ViewBag.Tournaments = tournaments;
            return PartialView();
        }

        [Editor]
        public ActionResult MatchesByTournament(int tournamentId)
        {
            logService.LogInfoMessage("Controller: Match, Action: MatchesByTournament");
            SelectList teams, teamsGuest;            
            teams = new SelectList(teamProvider.GetTeamsByTournament(tournamentId), "TeamId", "Name");            
            ViewBag.Teams = teams;

            teamsGuest = new SelectList(teamProvider.GetTeamsByTournament(tournamentId), "TeamId", "Name");             
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
            if (match.Teams != null)
            {
                if (match.Teams[0].TeamId != match.Teams[1].TeamId && match.Date > DateTime.Now)
                {
                    result = matchService.AddMatch(match);
                    flag = false;
                }
                if (!result || flag)
                {
                    ModelState.AddModelError("", "You can not add a match with the following parameters");
                    logService.LogError("Controller: Match, Action: AddMatch Don't add Match");

                    SelectList sports = GetSports();
                    if (sports == null)
                    {
                        return RedirectToAction("InfoError", "Error");
                    }
                    ViewBag.Sports = sports;

                    SelectList tournaments = GetTournaments(match.SportId, match.TournamentId);
                    if (tournaments == null)
                    {
                        return RedirectToAction("InfoDB", "Error");
                    }
                    ViewBag.Tournaments = tournaments;

                    IReadOnlyList<Team> teamsList = teamProvider.GetTeamsByTournament(match.TournamentId);
                    Team teamHome = teamsList.Where(t => t.TeamId == match.Teams[0].TeamId).First();
                    Team teamGuest = teamsList.Where(t => t.TeamId == match.Teams[1].TeamId).First();
                    if (teamsList.Count == 0 || teamHome == null || teamGuest == null)
                    {
                        logService.LogError("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                        return RedirectToAction("InfoDB", "Error");
                    }
                    SelectList teams = new SelectList(teamsList, "TeamId", "Name", new SelectListItem { Text = teamHome.Name, Value = teamHome.TeamId.ToString() });
                    ViewBag.Teams = teams;

                    SelectList teamsGuest = new SelectList(teamsList, "TeamId", "Name", new SelectListItem { Text = teamGuest.Name, Value = teamGuest.TeamId.ToString() });
                    ViewBag.TeamsGuest = teamsGuest;

                }

                else
                {
                    cacheService.DeleteCache(cacheSortKey);
                    cacheService.DeleteCache(cacheNavigationKey);
                    return RedirectToAction("ShowMatches");
                }
            }
            else
            {
                if (!result || flag)
                {
                    ModelState.AddModelError("", "You can not add a match with the following parameters");
                    logService.LogError("Controller: Match, Action: AddMatch Don't add Match");

                    SelectList sports = GetSports();
                    if (sports == null)
                    {
                        return RedirectToAction("InfoError", "Error");
                    }
                    ViewBag.Sports = sports;

                    SelectList tournaments = GetTournaments(match.SportId, match.TournamentId);
                    if (tournaments == null)
                    {
                        return RedirectToAction("InfoDB", "Error");
                    }
                    ViewBag.Tournaments = tournaments;

                    IReadOnlyList<Team> teamsList = teamProvider.GetTeamsByTournament(match.TournamentId);
                    Team teamHome = teamsList.Where(t => t.TeamId == match.Teams[0].TeamId).First();
                    Team teamGuest = teamsList.Where(t => t.TeamId == match.Teams[1].TeamId).First();
                    if (teamsList.Count == 0 || teamHome == null || teamGuest == null)
                    {
                        logService.LogError("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                        return RedirectToAction("InfoDB", "Error");
                    }
                    SelectList teams = new SelectList(teamsList, "TeamId", "Name", new SelectListItem { Text = teamHome.Name, Value = teamHome.TeamId.ToString() });
                    ViewBag.Teams = teams;

                    SelectList teamsGuest = new SelectList(teamsList, "TeamId", "Name", new SelectListItem { Text = teamGuest.Name, Value = teamGuest.TeamId.ToString() });
                    ViewBag.TeamsGuest = teamsGuest;
                }
                
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

            SelectList sports = GetSports(match.SportId);
            if (sports == null)
            {
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sports = sports;

            SelectList tournaments = GetTournaments(match.SportId, match.Tournament.TournamentId);
            if (tournaments == null)
            {
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Tournaments = tournaments;

            IReadOnlyList<Team> teamsList = teamProvider.GetTeamsByTournament(match.Tournament.TournamentId);
            Team teamHome = teamsList.Where(t => t.TeamId == match.Teams[0].TeamId).First();
            Team teamGuest = teamsList.Where(t => t.TeamId == match.Teams[1].TeamId).First();
            if (teamsList.Count == 0 || teamHome == null || teamGuest == null)
            {
                logService.LogError("Controller: Match, Action: AddMatch Don't GetTeamsByTournament");
                return RedirectToAction("InfoError", "Error");
            }
            SelectList teams = new SelectList(teamsList, "TeamId", "Name",teamHome.TeamId);            
            ViewBag.Teams = teams;
            
            SelectList teamsGuest = new SelectList(teamsList, "TeamId", "Name", teamGuest.TeamId);            
            ViewBag.TeamsGuest = teamsGuest;

            SelectList results = GetResults(match.Result.ResultId);
            if (results == null)
            {
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

                SelectList sports = GetSports(match.SportId);
                if (sports == null)
                {
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Sports = sports;

                SelectList tournaments = GetTournaments(match.SportId, match.TournamentId);
                if (tournaments == null)
                {
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Tournaments = tournaments;                

                IReadOnlyList<Team> teamsList = teamProvider.GetTeamsByTournament(match.TournamentId);
                if (teamsList == null)
                {
                    logService.LogError("Controller: Match, Action: AddMatch Don't GetTeamsAll");
                    return RedirectToAction("InfoError", "Error");
                }
                SelectList teams = new SelectList(teamsList, "TeamId", "Name", match.Teams[0].TeamId);                
                ViewBag.Teams = teams;
                                
                SelectList teamsGuest = new SelectList(teamsList, "TeamId", "Name", match.Teams[1].TeamId);                 
                ViewBag.TeamsGuest = teamsGuest;

                SelectList results = GetResults(match.Result.ResultId);
                if (results == null)
                {
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Results = results;                

            }
            else            
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
            ViewBag.Sport = sportProvider.GetSport(match.SportId).Name;

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
        public ActionResult ShowCoefficient(int id, DateTime date)
        {
            logService.LogInfoMessage("Controller: Match, Action: ShowCoefficient");
            IReadOnlyList<Event> events = matchProvider.GetEventByMatch(id);
            if (events == null)
            {
                logService.LogError("Controller: Match, Action: ShowCoefficient Don't Show Coefficient");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Date = date;
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