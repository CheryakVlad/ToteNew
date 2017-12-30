using System;
using System.Collections.Generic;
using Common.Models;
using Data.Clients;
using Data.Services;
using Common.Logger;

namespace Business.Providers
{
    public class TeamProvider : ITeamProvider
    {
        private readonly ITeamClient teamClient;
        private readonly IDataService dataService;
        private readonly ILogService<TeamProvider> logService;

        public TeamProvider(ITeamClient teamClient, IDataService dataService, ILogService<TeamProvider> logService)
        {
            if (teamClient == null || dataService == null)
            {
                throw new ArgumentNullException();
            }
            this.teamClient = teamClient;
            this.dataService = dataService;
            if (logService == null)
            {
                this.logService = new LogService<TeamProvider>();
            }
            else
            {
                this.logService = logService;
            }
        }
                

        /*public bool AddTeam(Team team)
        {
            return teamClient.AddTeam(team);
        }

        public bool DeleteTeam(int teamId)
        {
            return teamClient.DeleteTeam(teamId);
        }
        */
        public Team GetTeamById(int teamId)
        {
            if (teamId <= 0)
            {
                logService.LogError("Class: TeamProvider Method: GetTeamById  teamId must be positive");
                throw new ArgumentOutOfRangeException("teamId must be positive");
            }
            return dataService.GetTeamById(teamId);
        }

        public IReadOnlyList<Team> GetTeamsAll()
        {
            return dataService.GetTeamsAll();
        }

        /*public bool UpdateTeam(Team team)
        {
            return teamClient.UpdateTeam(team);
        }*/

        public IReadOnlyList<Country> GetCountriesAll()
        {
            return dataService.GetCountriesAll();
        }

        public IReadOnlyList<Team> GetTeamsByTournament(int tournamentId)
        {
            if (tournamentId <= 0)
            {
                logService.LogError("Class: TeamProvider Method: GetTeamsByTournament  tournamentId must be positive");
                throw new ArgumentOutOfRangeException("tournamentId must be positive");
            }
            return dataService.GetTeamsByTournament(tournamentId);
        }

        /*public bool UpdateCountry(Country country)
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
        }*/

        public Country GetCountryById(int countryId)
        {
            if (countryId <= 0)
            {
                logService.LogError("Class: TeamProvider Method: GetCountryById  countryId must be positive");
                throw new ArgumentOutOfRangeException("countryId must be positive");
            }
            return dataService.GetCountryById(countryId);                 
        }

        /*public bool AddTournamentForTeam(int tournamentId, int teamId)
        {
            return teamClient.AddTournamentForTeam(tournamentId, teamId);
        }

        public bool DeleteTournamentForTeam(int tournamentId, int teamId)
        {
            return teamClient.DeleteTournamentForTeam(tournamentId, teamId);
        }*/
    }
}
