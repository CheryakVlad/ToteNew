using System;
using Common.Models;
using Data.Clients;
using Common.Logger;

namespace Business.Service
{
    public class UpdateTeamService : IUpdateTeamService
    {
        private readonly ITeamClient teamClient;
        private readonly ILogService<UpdateTeamService> logService;
        public UpdateTeamService(ITeamClient teamClient, ILogService<UpdateTeamService> logService)
        {
            if (teamClient == null)
            {
                throw new ArgumentNullException();
            }
            this.teamClient = teamClient;
            if (logService == null)
            {
                this.logService = new LogService<UpdateTeamService>();
            }
            else
            {
                this.logService = logService;
            }
        }

        public bool AddCountry(Country country)
        {
            if (country == null)
            {
                logService.LogError("Class: UpdateTeamService Method: AddCountry  Country don't add to DB");
                throw new NullReferenceException("Country is null");
            }
            return teamClient.AddCountry(country);
        }

        public bool AddTeam(Team team)
        {
            if (team == null)
            {
                logService.LogError("Class: UpdateTeamService Method: AddTeam  Team don't add to DB");
                throw new NullReferenceException("Team is null");
            }
            return teamClient.AddTeam(team);
        }

        public bool AddTournamentForTeam(int tournamentId, int teamId)
        {
            if (tournamentId <= 0|| teamId<=0)            
            {
                logService.LogError("Class: UpdateTeamService Method: AddTournamentForTeam  Don't add tournament for team");
                throw new ArgumentOutOfRangeException("AddTournamentForTeam");
            }
            return teamClient.AddTournamentForTeam(tournamentId, teamId);
        }

        public bool DeleteCountry(int countryId)
        {
            if (countryId <= 0)
            {
                logService.LogError("Class: UpdateTeamService Method: DeleteCountry  Country don't delete from DB");
                throw new ArgumentOutOfRangeException("countryId <= 0");
            }
            return teamClient.DeleteCountry(countryId);
        }

        public bool DeleteTeam(int teamId)
        {
            if (teamId <= 0)
            {
                logService.LogError("Class: UpdateTeamService Method: DeleteTeam  Team don't delete from DB");
                throw new ArgumentOutOfRangeException("teamId <= 0");
            }
            return teamClient.DeleteTeam(teamId);
        }

        public bool DeleteTournamentForTeam(int tournamentId, int teamId)
        {
            if (teamId <= 0||tournamentId<=0)
            {
                logService.LogError("Class: UpdateTeamService Method: DeleteTournamentForTeam  Don't Delete Tournament For Team");
                throw new ArgumentOutOfRangeException("teamId <= 0");
            }
            return teamClient.DeleteTournamentForTeam(tournamentId, teamId);
        }

        public bool UpdateCountry(Country country)
        {
            if (country == null)
            {
                logService.LogError("Class: UpdateTeamService Method: UpdateCountry  Country don't update to DB");
                throw new NullReferenceException("Country is null");
            }
            return teamClient.UpdateCountry(country);
        }

        public bool UpdateTeam(Team team)
        {
            if (team == null)
            {
                logService.LogError("Class: UpdateTeamService Method: UpdateTeam  Team don't update to DB");
                throw new NullReferenceException("Team is null");
            }
            return teamClient.UpdateTeam(team);
        }
    }
}
