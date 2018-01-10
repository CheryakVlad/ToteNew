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
    public class TeamController : Controller
    {
        private readonly ITeamProvider teamProvider;        
        private readonly ITournamentProvider tournamentProvider;
        private readonly ISportProvider sportProvider;
        private readonly IUpdateTeamService teamService;       
        private readonly ILogService<TeamController> logService;

        public TeamController(ITeamProvider teamProvider, 
            IUpdateTeamService teamService, ITournamentProvider tournamentProvider, ISportProvider sportProvider) 
            :this(teamProvider, teamService, tournamentProvider, sportProvider, new LogService<TeamController>())
        {

        }

        public TeamController(ITeamProvider teamProvider, IUpdateTeamService teamService,
            ITournamentProvider tournamentProvider, ISportProvider sportProvider, ILogService<TeamController> logService)
        {
            if (logService == null)
            {
                this.logService = new LogService<TeamController>();
            }
            else
            {
                this.logService = logService;
            }
            if (teamProvider == null|| teamService==null || tournamentProvider == null || sportProvider == null)
            {
                logService.LogError("TeamController ArgumentNullException");
                throw new ArgumentNullException();
            }            
            this.teamProvider = teamProvider;
            this.teamService = teamService;
            this.tournamentProvider = tournamentProvider;
            this.sportProvider = sportProvider;            
        }
        
        [Editor]
        public ActionResult ShowCountries()
        {
            logService.LogInfoMessage("Controller: Team, Action: ShowCountries");
            IReadOnlyList<Country> countries = teamProvider.GetCountriesAll();
            if (countries.Count == 0)
            {
                logService.LogError("Controller: Team, Action: ShowCountries Don't GetCountriesAll");
                return RedirectToAction("InfoError", "Error");
            }
            return View(countries);
        }
        [Editor]
        public ActionResult ShowTeams()
        {
            logService.LogInfoMessage("Controller: Team, Action: ShowTeams");
            IReadOnlyList<Team> teams = teamProvider.GetTeamsAll();
            if (teams.Count == 0)
            {
                logService.LogError("Controller: Team, Action: ShowTeams Don't GetTeamsAll");
                return RedirectToAction("InfoError", "Error");
            }
            return PartialView(teams);
        }

        [HttpGet]
        [Editor]
        public ActionResult AddCountry()
        {
            logService.LogInfoMessage("Controller: Team, Action: AddCountry");
            return View();
        }

        [HttpPost]
        [Editor]
        public ActionResult AddCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                bool result = teamService.AddCountry(country);
                if (!result)
                {
                    ModelState.AddModelError("", "You can not add a country with the following parameters");
                    logService.LogError("Controller: Sport, Action: AddSport Don't add country");
                    return View(country);
                    
                }
                return RedirectToAction("ShowCountries");
            }
            else
            {
                return View();
            }         
        }
        private SelectList GetSports(int sport = 1)
        {
            IReadOnlyList<Sport> sportsAll = sportProvider.GetSports();
            if (sportsAll.Count == 0)
            {
                logService.LogError("Controller: Team, Don't GetSports");
                return null;
            }
            SelectList sports = new SelectList(sportsAll, "SportId", "Name", sport);

            return sports;
        }
        private SelectList GetCountries(int country = 1)
        {
            IReadOnlyList<Country> countriesAll = teamProvider.GetCountriesAll();
            if (countriesAll.Count == 0)
            {
                logService.LogError("Controller: Team, Don't GetCountriesAll");
                return null;
            }
            SelectList countries = new SelectList(countriesAll, "CountryId", "Name", country);

            return countries;
        }

        [HttpGet]
        [Editor]
        public ActionResult AddTeam()
        {
            logService.LogInfoMessage("Controller: Team, Action: AddTeam");

            SelectList sports = GetSports();
            if (sports == null)
            {
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sports = sports;
            
            SelectList countries = GetCountries();
            if (countries == null)
            {
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
                bool result = teamService.AddTeam(team);
                if (!result)
                {
                    SelectList sports = new SelectList(sportProvider.GetSports(), "SportId", "Name",team.SportId);
                    if (sports == null)
                    {
                        logService.LogError("Controller: Team, Action: AddTeam Don't GetSports");
                        return RedirectToAction("InfoError", "Error");
                    }
                    ViewBag.Sports = sports;
                    SelectList countries = new SelectList(teamProvider.GetCountriesAll(), "CountryId", "Name",team.CountryId);
                    if (countries == null)
                    {
                        logService.LogError("Controller: Team, Action: AddTeam Don't GetCountriesAll");
                        return RedirectToAction("InfoError", "Error");
                    }
                    ViewBag.Countries = countries;
                    ModelState.AddModelError("", "You can not add a team with the following parameters");
                    logService.LogError("Controller: Team, Action: AddTeam Don't add Team");
                    return View(team);
                }
                return RedirectToAction("ShowTeams");
            }
            else
            {
                ModelState.AddModelError("", "You can not add a team with the following parameters");
                logService.LogError("Controller: Team, Action: AddTeam Don't add Team");

                SelectList sports = new SelectList(sportProvider.GetSports(), "SportId", "Name", team.SportId);
                if (sports == null)
                {
                    logService.LogError("Controller: Team, Action: AddTeam Don't GetSports");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Sports = sports;
                SelectList countries = new SelectList(teamProvider.GetCountriesAll(), "CountryId", "Name", team.CountryId);
                if (countries == null)
                {
                    logService.LogError("Controller: Team, Action: AddTeam Don't GetCountriesAll");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Countries = countries;
                
                logService.LogError("Controller: Team, Action: AddTeam Don't add Team");
                return View(team);
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult EditCountry(int countryId)
        {
            logService.LogInfoMessage("Controller: Team, Action: EditCountry");
            Country country = teamProvider.GetCountryById(countryId);
            if (country == null)
            {
                logService.LogError("Controller: Team, Action: EditCountry Don't GetCountryById");
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
                bool result = teamService.UpdateCountry(country);
                if (!result)
                {
                    ModelState.AddModelError("", "You can not add a country with the following parameters");
                    logService.LogError("Controller: Sport, Action: AddSport Don't update country");
                    return View(country);                    
                }
                return RedirectToAction("ShowCountries");
            }
            else
            {
                ModelState.AddModelError("", "You can not add a country with the following parameters");
                logService.LogError("Controller: Sport, Action: AddSport Don't update country");
                return View(country);
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult EditTeam(int id)
        {
            logService.LogInfoMessage("Controller: Team, Action: EditTeam");
            SelectList sports = new SelectList(sportProvider.GetSports(), "SportId", "Name");
            if (sports == null)
            {
                logService.LogError("Controller: Team, Action: EditTeam Don't GetSports");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Sports = sports;
            SelectList countries = new SelectList(teamProvider.GetCountriesAll(), "CountryId", "Name");
            if (countries == null)
            {
                logService.LogError("Controller: Team, Action: EditTeam Don't GetCountriesAll");
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
                bool result = teamService.UpdateTeam(team);
                if (!result)
                {
                    SelectList sports = new SelectList(sportProvider.GetSports(), "SportId", "Name", team.SportId);
                    if (sports == null)
                    {
                        logService.LogError("Controller: Team, Action: AddTeam Don't GetSports");
                        return RedirectToAction("InfoError", "Error");
                    }
                    ViewBag.Sports = sports;
                    SelectList countries = new SelectList(teamProvider.GetCountriesAll(), "CountryId", "Name", team.CountryId);
                    if (countries == null)
                    {
                        logService.LogError("Controller: Team, Action: AddTeam Don't GetCountriesAll");
                        return RedirectToAction("InfoError", "Error");
                    }
                    ViewBag.Countries = countries;
                    ModelState.AddModelError("", "You can not edit a team with the following parameters");
                    logService.LogError("Controller: Team, Action: AddTeam Don't update team");
                    return View(team);
                }
                return RedirectToAction("ShowTeams");
            }
            else
            {
                ModelState.AddModelError("", "You can not edit a team with the following parameters");
                logService.LogError("Controller: Team, Action: AddTeam Don't update team");

                SelectList sports = new SelectList(sportProvider.GetSports(), "SportId", "Name", team.SportId);
                if (sports == null)
                {
                    logService.LogError("Controller: Team, Action: AddTeam Don't GetSports");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Sports = sports;
                SelectList countries = new SelectList(teamProvider.GetCountriesAll(), "CountryId", "Name", team.CountryId);
                if (countries == null)
                {
                    logService.LogError("Controller: Team, Action: AddTeam Don't GetCountriesAll");
                    return RedirectToAction("InfoError", "Error");
                }
                ViewBag.Countries = countries;
                
                logService.LogError("Controller: Team, Action: AddTeam Don't add Team");
                return View(team);
            }
        }

        [HttpGet]
        [Editor]
        public ActionResult DeleteTeam(int id)
        {
            logService.LogInfoMessage("Controller: Team, Action: DeleteTeam");
            Team team = teamProvider.GetTeamById(id);
            if (team == null)
            {
                logService.LogError("Controller: Team, Action: DeleteTeam Don't GetTeamById");
                return RedirectToAction("InfoError", "Error");
            }
            return View(team);
        }

        [HttpPost]
        [Editor]
        [ActionName("DeleteTeam")]
        public ActionResult Delete(int teamId)
        {
            bool result = teamService.DeleteTeam(teamId);
            if (!result)
            {
                logService.LogError("Controller: Team, Action: DeleteTeam Don't delete Team");
            }
            return RedirectToAction("ShowTeams");
        }

        [HttpGet]
        [Editor]
        public ActionResult DeleteCountry(int countryId)
        {
            logService.LogInfoMessage("Controller: Team, Action: DeleteCountry");
            Country country = teamProvider.GetCountryById(countryId);
            if (country == null)
            {
                logService.LogError("Controller: Team, Action: DeleteCountry Don't GetCountryById");
                return RedirectToAction("InfoError", "Error");
            }
            return View(country);
        }

        [HttpPost]
        [Editor]
        [ActionName("DeleteCountry")]
        public ActionResult DeleteCountry_(int countryId)
        {
            bool result = teamService.DeleteCountry(countryId);
            if (!result)
            {
                logService.LogError("Controller: Team, Action: DeleteTeam Don't delete Team");
            }
            return RedirectToAction("ShowCountries");
        }

        [Editor]
        public ActionResult ShowTournamentsByTeam(int id)
        {
            logService.LogInfoMessage("Controller: Team, Action: ShowTournamentsByTeam");
            Team team = teamProvider.GetTeamById(id);
            if(team == null)
            {
                logService.LogError("Controller: Team, Action: ShowTournamentsByTeam Don't GetTeamById");
                return RedirectToAction("InfoError", "Error");
            }
            ViewBag.Team = team;
            IReadOnlyList<Tournament> tournaments = tournamentProvider.GetTournamentesByTeamId(id);
            if(tournaments.Count == 0)
            {
                logService.LogError("Controller: Team, Action: ShowTournamentsByTeam Don't GetTournamentesByTeamId");
                return RedirectToAction("InfoDB", "Error");
            }
            return View(tournaments);
        }

        [HttpGet]
        [Editor]
        public ActionResult AddTournamentForTeam(int id)
        {
            logService.LogInfoMessage("Controller: Team, Action: AddTournamentForTeam");
            Team team = teamProvider.GetTeamById(id);            
            List<Tournament> tournamentesSport = tournamentProvider.GetTournament(team.SportId) as List<Tournament>;
            List<Tournament> tournamentesTeam = tournamentProvider.GetTournamentesByTeamId(id) as List<Tournament>;
            if (tournamentesSport.Count == 0 || tournamentesTeam.Count == 0)
            {
                logService.LogError("Controller: Team, Action: AddTournamentForTeam Don't GetTournamentes");
                return RedirectToAction("InfoError", "Error");
            }
            tournamentesSport.RemoveAll(element=> tournamentesTeam.Exists(elementTeam => elementTeam.TournamentId == element.TournamentId));
            SelectList tournaments = new SelectList(tournamentesSport, "TournamentId", "Name");            
            ViewBag.Tournaments = tournaments;
                        
            return View(team);
        }

        [HttpPost]
        [Editor]
        public ActionResult AddTournamentForTeam(Team team)
        {
            bool result = teamService.AddTournamentForTeam(team.Tournament.TournamentId, team.TeamId);
            if (!result)
            {
                logService.LogError("Controller: Team, Action: AddTournamentForTeam Don't add Tournament For Team");                
            }
            return RedirectToAction("ShowTournamentsByTeam", new { id=team.TeamId});
            
        }

        [HttpGet]
        [Editor]
        public ActionResult DeleteTournamentForTeam(int teamId, int tournamentId)            
        {
            logService.LogInfoMessage("Controller: Team, Action: DeleteTournamentForTeam");
            Team team = teamProvider.GetTeamById(teamId);            
            ViewBag.Team = team;
            Tournament tournament = tournamentProvider.GetTournamentById(tournamentId);
            if(team == null || tournament == null)
            {
                logService.LogError("Controller: Team, Action: DeleteTournamentForTeam Don't GetTournamentById or GetTeamById");
                return RedirectToAction("InfoError", "Error");
            }
            return View(tournament);
        }

        [HttpPost]
        [Editor]
        [ActionName("DeleteTournamentForTeam")]
        public ActionResult DeleteTournamentTeam(int teamId, int tournamentId)
        {
            bool result = teamService.DeleteTournamentForTeam(tournamentId, teamId);
            if (!result)
            {
                logService.LogError("Controller: Team, Action: DeleteTournamentForTeam Don't Delete Tournament For Team");
            }
            return RedirectToAction("ShowTournamentsByTeam", new { id = teamId });
        }

    }
}