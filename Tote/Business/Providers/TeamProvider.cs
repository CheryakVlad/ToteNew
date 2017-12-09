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
    }
}
