using System;
using System.Collections.Generic;
using Common.Models;
using Data.Clients;
using Data.Services;

namespace Business.Providers
{
    public class TeamProvider : ITeamProvider
    {
        private readonly ITeamClient teamClient;
        private readonly IDataService dataService;

        public TeamProvider(ITeamClient teamClient, IDataService dataService)
        {
            this.teamClient = teamClient;
            this.dataService = dataService;
        }

        public static TeamProvider createTeamProvider(ITeamClient teamClient, IDataService dataService)
        {
            if (teamClient == null || dataService == null)
            {
                throw new ArgumentNullException();
            }
            return new TeamProvider(teamClient, dataService);
        }

        public bool AddTeam(Team team)
        {
            return teamClient.AddTeam(team);
        }

        public bool DeleteTeam(int teamId)
        {
            return teamClient.DeleteTeam(teamId);
        }

        public Team GetTeamById(int teamId)
        {
            return dataService.GetTeamById(teamId);
        }

        public IReadOnlyList<Team> GetTeamsAll()
        {
            return dataService.GetTeamsAll();
        }

        public bool UpdateTeam(Team team)
        {
            return teamClient.UpdateTeam(team);
        }

        public IReadOnlyList<Country> GetCountriesAll()
        {
            return dataService.GetCountriesAll();
        }

        public IReadOnlyList<Team> GetTeamsByTournament(int tournamentId)
        {
            return dataService.GetTeamsByTournament(tournamentId);
        }

        public bool UpdateCountry(Country country)
        {
            return teamClient.UpdateCountry(country);
        }

        public bool AddCountry(Country country)
        {
            return teamClient.AddCountry(country);
        }

        public bool DeleteCountry(int countryId)
        {
            return teamClient.DeleteCountry(countryId);
        }

        public Country GetCountryById(int countryId)
        {
            return dataService.GetCountryById(countryId);                 
        }

        public bool AddTournamentForTeam(int tournamentId, int teamId)
        {
            return teamClient.AddTournamentForTeam(tournamentId, teamId);
        }

        public bool DeleteTournamentForTeam(int tournamentId, int teamId)
        {
            return teamClient.DeleteTournamentForTeam(tournamentId, teamId);
        }
    }
}
