using System;
using Common.Models;
using Data.Clients;
using Data.Services;
using Common.Logger;
using System.Collections.Generic;

namespace Business.Providers
{
    public class TournamentProvider : ITournamentProvider
    {
        private readonly ITournamentClient tournamentClient;
        private readonly ITournamentService tournamentService;
        private readonly ILogService<TournamentProvider> logService;

        public TournamentProvider(ITournamentClient tournamentClient, ITournamentService tournamentService, ILogService<TournamentProvider> logService)
        {
            if (tournamentClient == null || tournamentService == null)
            {
                throw new ArgumentNullException();
            }
            this.tournamentClient = tournamentClient;
            this.tournamentService = tournamentService;
            if (logService == null)
            {
                this.logService = new LogService<TournamentProvider>();
            }
            else
            {
                this.logService = logService;
            }
        }
        

        public Tournament GetTournamentById(int tournamentId)
        {
            if (tournamentId <= 0)
            {
                logService.LogError("Class: TournamentProvider Method: GetTournamentById  tournamentId must be positive");
                return null;
            }
            return tournamentService.GetTournamentById(tournamentId);
        }

        public IReadOnlyList<Tournament> GetTournament(int? sportId)
        {
            return tournamentService.GetTournament(sportId);
        }

        public IReadOnlyList<Tournament> GetTournamentes()
        {
            return tournamentService.GetTournamentes();
        }

        public IReadOnlyList<Tournament> GetTournamentesByTeamId(int teamId)
        {
            if (teamId <= 0)
            {
                logService.LogError("Class: BetListProvider Method: GetTournamentesByTeamId  teamId can not negative");
                return null;
            }
            return tournamentService.GetTournamentesByTeamId(teamId);
        }

    }
}
