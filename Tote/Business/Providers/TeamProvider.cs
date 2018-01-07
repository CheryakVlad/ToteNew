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
        private readonly ITeamService teamService;
        private readonly ILogService<TeamProvider> logService;

        public TeamProvider(ITeamClient teamClient, ITeamService teamService, ILogService<TeamProvider> logService)
        {
            if (teamClient == null || teamService == null)
            {
                throw new ArgumentNullException();
            }
            this.teamClient = teamClient;
            this.teamService = teamService;
            if (logService == null)
            {
                this.logService = new LogService<TeamProvider>();
            }
            else
            {
                this.logService = logService;
            }
        }
                
        
        public Team GetTeamById(int teamId)
        {
            if (teamId <= 0)
            {
                logService.LogError("Class: TeamProvider Method: GetTeamById  teamId must be positive");
                return null;
            }
            return teamService.GetTeamById(teamId);
        }

        public IReadOnlyList<Team> GetTeamsAll()
        {
            return teamService.GetTeamsAll();
        }
        
        public IReadOnlyList<Country> GetCountriesAll()
        {
            return teamService.GetCountriesAll();
        }

        public IReadOnlyList<Team> GetTeamsByTournament(int tournamentId)
        {
            if (tournamentId < 0)
            {
                logService.LogError("Class: TeamProvider Method: GetTeamsByTournament  tournamentId must be not negative");
                return null;                
            }
            return teamService.GetTeamsByTournament(tournamentId);
        }

        
        public Country GetCountryById(int countryId)
        {
            if (countryId <= 0)
            {
                logService.LogError("Class: TeamProvider Method: GetCountryById  countryId must be positive");
                return null;
            }
            return teamService.GetCountryById(countryId);                 
        }        
    }
}
