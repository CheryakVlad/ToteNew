
using Common.Logger;
using Common.Models;
using Data.Business;
using Data.Clients;
using System;
using System.Collections.Generic;

namespace Data.Services
{
    public class TeamService:ITeamService
    {        
        private readonly ITeamClient teamClient;
        private readonly ITeamConvert teamConvert;        
        private readonly ILogService<TeamService> logService;

        public TeamService(ITeamConvert teamConvert, ITeamClient teamClient, ILogService<TeamService> logService)
        {
            if (teamConvert == null || teamClient == null)
            {
                throw new ArgumentNullException();
            }            
            this.teamConvert = teamConvert;            
            this.teamClient = teamClient;            
            if (logService == null)
            {
                this.logService = new LogService<TeamService>();
            }
            else
            {
                this.logService = logService;
            }
        }

        public IReadOnlyList<Team> GetTeamsAll()
        {
            var dto = teamClient.GetTeamsAll();

            if (dto != null)
            {
                return teamConvert.ToTeams(dto);
            }
            logService.LogError("Class: DataService Method: GetTeamsAll List<Team> is null");
            return new List<Team>();
        }

        public Team GetTeamById(int teamId)
        {
            var dto = teamClient.GetTeamById(teamId);
            if (dto != null)
            {
                return teamConvert.ToTeam(dto);
            }
            logService.LogError("Class: DataService Method: GetTeamById Team is null");
            return new Team();
        }

        public IReadOnlyList<Team> GetTeamsByTournament(int tournamentId)
        {
            var dto = teamClient.GetTeamsByTournament(tournamentId);

            if (dto != null)
            {
                return teamConvert.ToTeams(dto);
            }
            logService.LogError("Class: DataService Method: GetTeamsByTournament List<Team> is null");
            return new List<Team>();
        }

        public IReadOnlyList<Country> GetCountriesAll()
        {
            var dto = teamClient.GetCountriesAll();
            if (dto != null)
            {
                return teamConvert.ToCountry(dto);
            }
            logService.LogError("Class: DataService Method: GetCountriesAll List<Country> is null");
            return new List<Country>();
        }

        public Country GetCountryById(int countryId)
        {
            var dto = teamClient.GetCountryById(countryId);
            if (dto != null)
            {
                return teamConvert.ToCountry(dto);
            }
            logService.LogError("Class: DataService Method: GetCountryById Country is null");
            return new Country();
        }

    }
}
