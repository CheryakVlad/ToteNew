using Business.Providers;
using Common.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Tote.Controllers
{
    public class MatchController : Controller
    {
        private IMatchProvider matchProvider;
        private IBetListProvider betListProvider;
        private ITeamProvider teamProvider;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MatchController));

        public MatchController(IBetListProvider betListProvider, IMatchProvider matchProvider, ITeamProvider teamProvider)
        {
            this.betListProvider = betListProvider;
            this.matchProvider = matchProvider;
            this.teamProvider = teamProvider;
        }

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
        public ActionResult AddMatch()
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            SelectList tournaments = new SelectList(betListProvider.GetTournamentes(), "TournamentId", "Name");
            ViewBag.Tournaments = tournaments;
            SelectList teams = new SelectList(teamProvider.GetTeamsAll(), "TeamId", "Name");
            ViewBag.Teams = teams;
            /*SelectList country = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;*/
            return View();
        }

        public ActionResult TournamentesBySport(int sportId)
        {
            SelectList tournaments = new SelectList(betListProvider.GetTournament(sportId), "TournamentId", "Name");
            ViewBag.Tournaments = tournaments;
            return PartialView();
        }

        public ActionResult MatchesByTournament(int tournamentId)
        {
            SelectList teams = new SelectList(teamProvider.GetTeamsByTournament(tournamentId), "TeamId", "Name");
            ViewBag.Teams = teams;
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddMatch(Match match)
        {

            bool result = matchProvider.AddMatch(match);
            if (!result)
            {
                log.Error("Controller: Match, Action: AddMatch Don't add Match");
            }

            return RedirectToAction("ShowMatches");
        }

        [HttpGet]
        public ActionResult EditMatch(int id)
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            /*country*/
            Match match = matchProvider.GetMatchById(id);

            return View(match);
        }
        [HttpPost]
        public ActionResult EditTeam(Match match)
        {
            bool result = matchProvider.UpdateMatch(match);
            if (!result)
            {
                log.Error("Controller: Match, Action: EditMatch Don't update Match");
            }
            return RedirectToAction("ShowMatches");
        }

        [HttpGet]
        public ActionResult DeleteMatch(int id)
        {
            Match match = matchProvider.GetMatchById(id);
            return View(match);
        }

        [HttpPost]
        [ActionName("DeleteMatch")]
        public ActionResult Delete(int matchId)
        {
            bool result = matchProvider.DeleteMatch(matchId);
            if (!result)
            {
                log.Error("Controller: Match, Action: DeleteMatch Don't delete Match");
            }
            return RedirectToAction("ShowMatches");
        }



    }
}