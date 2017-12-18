using Business.Providers;
using Business.Service;
using Common.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Tote.Attribute;

namespace Tote.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchProvider matchProvider;
        private readonly IBetListProvider betListProvider;
        private readonly ITeamProvider teamProvider;
        private readonly ICacheService cacheService;
        private const string cacheKey = "sortKey";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MatchController));

        public MatchController(IBetListProvider betListProvider, IMatchProvider matchProvider, ITeamProvider teamProvider, ICacheService cacheService)
        {
            this.betListProvider = betListProvider;
            this.matchProvider = matchProvider;
            this.teamProvider = teamProvider;
            this.cacheService = cacheService;
        }
        [Editor]
        public ActionResult ShowMatches()
        {
            IReadOnlyList<Match> matches = matchProvider.GetMatchesAll();
            if (matches == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return PartialView(matches);
        }
        [HttpGet]
        [Editor]
        public ActionResult AddMatch()
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            SelectList tournaments = new SelectList(betListProvider.GetTournamentes(), "TournamentId", "Name");
            ViewBag.Tournaments = tournaments;
            SelectList teams = new SelectList(teamProvider.GetTeamsAll(), "TeamId", "Name");
            ViewBag.Teams = teams;            
            return View();
        }
        [Editor]
        public ActionResult TournamentesBySport(int sportId)
        {
            SelectList tournaments = new SelectList(betListProvider.GetTournament(sportId), "TournamentId", "Name");
            ViewBag.Tournaments = tournaments;
            return PartialView();
        }
        [Editor]
        public ActionResult MatchesByTournament(int tournamentId)
        {
            SelectList teams = new SelectList(teamProvider.GetTeamsByTournament(tournamentId), "TeamId", "Name");
            ViewBag.Teams = teams;
            return PartialView();
        }

        [HttpPost]
        [Editor]
        public ActionResult AddMatch(Match match)
        {
            /*if (ModelState.IsValid)
            {*/
                Result res = new Result { ResultId = 3 };

                match.Result = res;
                match.Score = "0";
                bool result = matchProvider.AddMatch(match);
                if (!result)
                {
                    log.Error("Controller: Match, Action: AddMatch Don't add Match");
                }
                else
                {
                    cacheService.DeleteCache();
                }

                return RedirectToAction("ShowMatches");
           /* }
            else
            {
                SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
                ViewBag.Sports = sports;
                SelectList tournaments = new SelectList(betListProvider.GetTournamentes(), "TournamentId", "Name");
                ViewBag.Tournaments = tournaments;
                SelectList teams = new SelectList(teamProvider.GetTeamsAll(), "TeamId", "Name");
                ViewBag.Teams = teams;
                return View();
            }*/
        }

        [HttpGet]
        [Editor]
        public ActionResult EditMatch(int id)
        {
            
            Match match = matchProvider.GetMatchById(id);

            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name", match.SportId);
            ViewBag.Sports = sports;
            int selected = match.Tournament.TournamentId;
            SelectList tournaments = new SelectList(betListProvider.GetTournamentes(), "TournamentId", "Name", selected);
            ViewBag.Tournaments = betListProvider.GetTournamentes();
            IReadOnlyList<Team> teamsAll = teamProvider.GetTeamsAll();
            selected = match.Teams[0].TeamId;
            SelectList teamsHome = new SelectList(teamsAll, "TeamId", "Name", selected);
            ViewBag.TeamsHome = teamsHome;
            selected = match.Teams[1].TeamId;
            SelectList teamsGuest = new SelectList(teamsAll, "TeamId", "Name", selected);
            ViewBag.TeamsGuest = teamsGuest;
            selected = match.Result.ResultId;
            SelectList results = new SelectList(matchProvider.GetResultsAll(),"ResultId","Name", selected);
            ViewBag.Results = results;
            return View(match);
        }

        [HttpPost]
        [Editor]
        public ActionResult EditMatch(Match match)
        {
            /*if (ModelState.IsValid)
            {*/
                bool result = matchProvider.UpdateMatch(match);
                if (!result)
                {
                    log.Error("Controller: Match, Action: EditMatch Don't update Match");
                }
                else
                {
                    cacheService.DeleteCache();
                }
                return RedirectToAction("ShowMatches");
            /*}
            else
            {
                SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name", match.SportId);
                ViewBag.Sports = sports;
                int selected = match.Tournament.TournamentId;
                SelectList tournaments = new SelectList(betListProvider.GetTournamentes(), "TournamentId", "Name", selected);
                ViewBag.Tournaments = betListProvider.GetTournamentes();
                IReadOnlyList<Team> teamsAll = teamProvider.GetTeamsAll();
                selected = match.Teams[0].TeamId;
                SelectList teamsHome = new SelectList(teamsAll, "TeamId", "Name", selected);
                ViewBag.TeamsHome = teamsHome;
                selected = match.Teams[1].TeamId;
                SelectList teamsGuest = new SelectList(teamsAll, "TeamId", "Name", selected);
                ViewBag.TeamsGuest = teamsGuest;
                selected = match.Result.ResultId;
                SelectList results = new SelectList(matchProvider.GetResultsAll(), "ResultId", "Name", selected);
                ViewBag.Results = results;
                return View();
            }*/
        }

        [HttpGet]
        [Editor]
        public ActionResult DeleteMatch(int id)
        {
            Match match = matchProvider.GetMatchById(id);            
            ViewBag.Sport = betListProvider.GetSport(match.SportId).Name;

            return View(match);
        }

        [HttpPost]
        [Editor]
        [ActionName("DeleteMatch")]
        public ActionResult Delete(int matchId)
        {
            bool result = matchProvider.DeleteMatch(matchId);
            if (!result)
            {
                log.Error("Controller: Match, Action: DeleteMatch Don't delete Match");
            }
            else
            {
                cacheService.DeleteCache();
            }
            return RedirectToAction("ShowMatches");
        }
        [Editor]
        public ActionResult ShowCoefficient(int id)
        {
            IReadOnlyList<Event> events = matchProvider.GetEventByMatch(id);
            if (events == null)
            {
                return RedirectToAction("InfoError", "Navigation");
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
                bool result = matchProvider.AddEvent(item.ToArray());
                if (!result)
                {
                    log.Error("Controller: Match, Action: EditMatch Don't update Match");
                }
                else
                {
                    cacheService.DeleteCache();
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
            IReadOnlyList<Event> events = matchProvider.GetEventByMatch(id);            
            return View(events);
        }

        [HttpPost]
        [Editor]
        public ActionResult EditEvent(List<Event> item)
        {            
            if (ModelState.IsValid)
            {
                bool result = matchProvider.UpdateEvent(item.ToArray());
                if (!result)
                {
                    log.Error("Controller: Match, Action: EditMatch Don't update Match");
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
            bool result = matchProvider.DeleteEvent(matchId);
            if (!result)
            {
                log.Error("Controller: Match, Action: DeleteMatch Don't delete Match");
            }
            return RedirectToAction("ShowMatches");
        }


    }
}