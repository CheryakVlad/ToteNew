﻿using Business.Providers;
using Common.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Tote.Controllers
{
    public class TeamController : Controller
    {
        private ITeamProvider teamProvider;
        private IBetListProvider betListProvider;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TeamController));

        public TeamController(IBetListProvider betListProvider, ITeamProvider teamProvider)
        {
            this.betListProvider = betListProvider;
            this.teamProvider = teamProvider;
        }
        public ActionResult ShowCountries()
        {
            IReadOnlyList<Country> countries = teamProvider.GetCountriesAll();
            if (countries == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(countries);
        }
        public ActionResult ShowTeams()
        {
            IReadOnlyList<Team> teams = teamProvider.GetTeamsAll();
            if (teams == null)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return PartialView(teams);
        }

        [HttpGet]
        public ActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
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
        public ActionResult AddTeam()
        {
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            SelectList countries = new SelectList(teamProvider.GetCountriesAll(), "CountryId", "Name");
            ViewBag.Countries = countries;
            return View();
        }

        [HttpPost]
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
        public ActionResult EditCountry(int countryId)
        {
            Country country = teamProvider.GetCountryById(countryId);
            return View(country);
        }
        [HttpPost]
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
        public ActionResult EditTeam(int id)
        {            
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            SelectList countries = new SelectList(teamProvider.GetCountriesAll(), "CountryId", "Name");
            ViewBag.Countries = countries;
            Team team = teamProvider.GetTeamById(id);

            return View(team);
        }
        [HttpPost]
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
        public ActionResult DeleteTeam(int id)
        {
            Team team = teamProvider.GetTeamById(id);
            return View(team);
        }

        [HttpPost]
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
        public ActionResult DeleteCountry(int countryId)
        {
            Country country = teamProvider.GetCountryById(countryId);
            return View(country);
        }

        [HttpPost]
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


    }
}