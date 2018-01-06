using Common.Logger;
using Common.Models;
using Data.Business;
using Data.Clients;
using System;
using System.Collections.Generic;

namespace Data.Services
{
    public class TournamentService : ITournamentService
    {
        
        private readonly ITournamentClient tournamentClient;        
        private readonly ITournamentConvert tournamentConvert;        
        private readonly ILogService<TournamentService> logService;

        public TournamentService(ITournamentConvert tournamentConvert, ITournamentClient tournamentClient,
            ILogService<TournamentService> logService)
        {
            if (tournamentConvert == null || tournamentClient == null)
            {
                throw new ArgumentNullException();
            }           
            this.tournamentConvert = tournamentConvert;
            this.tournamentClient = tournamentClient;            
            if (logService == null)
            {
                this.logService = new LogService<TournamentService>();
            }
            else
            {
                this.logService = logService;
            }
        }

        public IReadOnlyList<Tournament> GetTournamentesByTeamId(int teamId)
        {
            var dto = tournamentClient.GetTournamentesByTeamId(teamId);

            if (dto != null)
            {
                return tournamentConvert.ToTournament(dto);
            }
            logService.LogError("Class: DataService Method: GetTournamentesByTeamId List<Tournament> is null");
            return new List<Tournament>();
        }

        public IReadOnlyList<Tournament> GetTournament(int? sportId)
        {
            var dto = tournamentClient.GetTournament(sportId);

            if (dto != null)
            {
                return tournamentConvert.ToTournament(dto);
            }
            logService.LogError("Class: DataService Method: GetTournament List<Tournament> is null");
            return new List<Tournament>();
        }

        public Tournament GetTournamentById(int tournamentId)
        {
            var dto = tournamentClient.GetTournamentById(tournamentId);

            if (dto != null)
            {
                return tournamentConvert.ToTournament(dto);
            }
            logService.LogError("Class: DataService Method: GetTournament List<Tournament> is null");
            return new Tournament();
        }

        public IReadOnlyList<Tournament> GetTournamentes()
        {
            var dto = tournamentClient.GetTournamentes();

            if (dto != null)
            {
                return tournamentConvert.ToTournament(dto);
            }
            logService.LogError("Class: DataService Method: GetTournamentes List<Tournament> is null");
            return new List<Tournament>();
        }

    }
}
