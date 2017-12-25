using Business.Providers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tote.Attribute;

namespace Tote.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamProvider teamProvider;
        private readonly IBetListProvider betListProvider;
        private readonly log4net.ILog log;

        public TeamController(IBetListProvider betListProvider, ITeamProvider teamProvider)
        {
            this.betListProvider = betListProvider;
            this.teamProvider = teamProvider;
            this.log = log4net.LogManager.GetLogger(typeof(TeamController));
        }

        public static TeamController createMatchController(IBetListProvider betListProvider, ITeamProvider teamProvider)
        {
            if (betListProvider == null || teamProvider == null)
            {
                throw new ArgumentNullException();
            }
            return new TeamController(betListProvider, teamProvider);
        }

        [Editor]
        public ActionResult ShowCountries()
        {
            IReadOnlyList<Country> countries = teamProvider.GetCountriesAll();
            if (countries == null)
            {
                log.Error("Controller: Team, Action: ShowCountries Don't GetCountriesAll");
                return RedirectToAction("InfoError", "Error");
            }
            return View(countries);
        }
        [Editor]
        public ActionResult ShowTeams()
        {
            IReadOnlyList<Team> teams = teamProvider.GetTeamsAll();
            if (teams == null)
            {
                log.Error("Controller: Team, Action: ShowTeams Don't GetTeamsAll");
                return RedirectToAction("InfoError", "Error");
            }
            return PartialView(teams);
        }

        [HttpGet]
        [Editor]
        public ActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        [Editor]
        public ActionResult AddCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                bool result = teamProvider.AddCountry(country);
                if (!result)
                {
                    log.Error("Controller: Team, Action: AddTeam Don't add Team");
                }
                return RedirectToAction("ShowCountries");
            }
            else
            {
                return View();
            }         
        }

        [HttpGet]
        [Editor]
        public ActionResult AddTeam()
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            if (sports == null)
            {
                log.Error("Controller: Team, Action: AddTeam Don't GetSports");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sports = sports;
            SelectList countries = new SelectList(teamProvider.GetCountriesAll(), "CountryId", "Name");
            if (countries == null)
            {
                log.Error("Controller: Team, Action: AddTeam Don't GetCountriesAll");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Countries = countries;
            return View();
        }

        [HttpPost]
        [Editor]
        public ActionResult AddTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                bool result = teamProvider.AddTeam(team);
                if (!result)
                {
                    log.Error("Controller: Team, Action: AddTeam Don't add Team");
                }
                return RedirectToAction("ShowTeams");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult EditCountry(int countryId)
        {
            Country country = teamProvider.GetCountryById(countryId);
            if (country == null)
            {
                log.Error("Controller: Team, Action: EditCountry Don't GetCountryById");
                return RedirectToAction("InfoError", "Error");
            }
            return View(country);
        }
        [HttpPost]
        [Editor]
        public ActionResult EditCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                bool result = teamProvider.UpdateCountry(country);
                if (!result)
                {
                    log.Error("Controller: Team, Action: EditTeam Don't update Team");
                }
                return RedirectToAction("ShowCountries");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult EditTeam(int id)
        {            
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            if (sports == null)
            {
                log.Error("Controller: Team, Action: EditTeam Don't GetSports");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sports = sports;
            SelectList countries = new SelectList(teamProvider.GetCountriesAll(), "CountryId", "Name");
            if (countries == null)
            {
                log.Error("Controller: Team, Action: EditTeam Don't GetCountriesAll");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Countries = countries;
            Team team = teamProvider.GetTeamById(id);

            return View(team);
        }
        [HttpPost]
        [Editor]
        public ActionResult EditTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                bool result = teamProvider.UpdateTeam(team);
                if (!result)
                {
                    log.Error("Controller: Team, Action: EditTeam Don't update Team");
                }
                return RedirectToAction("ShowTeams");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult DeleteTeam(int id)
        {
            Team team = teamProvider.GetTeamById(id);
            if (team == null)
            {
                log.Error("Controller: Team, Action: DeleteTeam Don't GetTeamById");
                return RedirectToAction("InfoError", "Error");
            }
            return View(team);
        }

        [HttpPost]
        [Editor]
        [ActionName("DeleteTeam")]
        public ActionResult Delete(int teamId)
        {
            bool result = teamProvider.DeleteTeam(teamId);
            if (!result)
            {
                log.Error("Controller: Team, Action: DeleteTeam Don't delete Team");
            }
            return RedirectToAction("ShowTeams");
        }

        [HttpGet]
        [Editor]
        public ActionResult DeleteCountry(int countryId)
        {
            Country country = teamProvider.GetCountryById(countryId);
            if (country == null)
            {
                log.Error("Controller: Team, Action: DeleteCountry Don't GetCountryById");
                return RedirectToAction("InfoError", "Error");
            }
            return View(country);
        }

        [HttpPost]
        [Editor]
        [ActionName("DeleteCountry")]
        public ActionResult DeleteCountry_(int countryId)
        {
            bool result = teamProvider.DeleteCountry(countryId);
            if (!result)
            {
                log.Error("Controller: Team, Action: DeleteTeam Don't delete Team");
            }
            return RedirectToAction("ShowCountries");
        }

        [Editor]
        public ActionResult ShowTournamentsByTeam(int id)
        {
            Team team = teamProvider.GetTeamById(id);
            ViewBag.Team = team;
            IReadOnlyList<Tournament> tournaments = betListProvider.GetTournamentesByTeamId(id);
            return View(tournaments);
        }

        [HttpGet]
        [Editor]
        public ActionResult AddTournamentForTeam(int id)
        {
            Team team = teamProvider.GetTeamById(id);            
            List<Tournament> tournamentesSport = betListProvider.GetTournament(team.SportId) as List<Tournament>;
            List<Tournament> tournamentesTeam = betListProvider.GetTournamentesByTeamId(id) as List<Tournament>;
            tournamentesSport.RemoveAll(element=> tournamentesTeam.Exists(elementTeam => elementTeam.TournamentId == element.TournamentId));
            SelectList tournaments = new SelectList(tournamentesSport, "TournamentId", "Name");
            if (tournaments == null)
            {
                log.Error("Controller: Team, Action: AddTournamentForTeam Don't GetTournamentes");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Tournaments = tournaments;
                        
            return View(team);
        }

        [HttpPost]
        [Editor]
        public ActionResult AddTournamentForTeam(Team team)
        {
            bool result = teamProvider.AddTournamentForTeam(team.Tournament.TournamentId, team.TeamId);
            if (!result)
            {
                log.Error("Controller: Team, Action: AddTournamentForTeam Don't add Tournament For Team");
            }
            return RedirectToAction("ShowTournamentsByTeam", new { id=team.TeamId});
            
        }

        [HttpGet]
        [Editor]
        public ActionResult DeleteTournamentForTeam(int teamId, int tournamentId)            
        {
            Team team = teamProvider.GetTeamById(teamId);
            ViewBag.Team = team;
            Tournament tournament = betListProvider.GetTournamentById(tournamentId);
            return View(tournament);
        }

        [HttpPost]
        [Editor]
        [ActionName("DeleteTournamentForTeam")]
        public ActionResult DeleteTournamentTeam(int teamId, int tournamentId)
        {
            bool result = teamProvider.DeleteTournamentForTeam(tournamentId, teamId);
            if (!result)
            {
                log.Error("Controller: Team, Action: DeleteTournamentForTeam Don't Delete Tournament For Team");
            }
            return RedirectToAction("ShowTournamentsByTeam", new { id = teamId });
        }

    }
}