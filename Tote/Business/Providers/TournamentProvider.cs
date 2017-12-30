using System;
using Common.Models;
using Data.Clients;
using Data.Services;
using Common.Logger;

namespace Business.Providers
{
    public class TournamentProvider : ITournamentProvider
    {
        private readonly ITournamentClient tournamentClient;
        private readonly IDataService dataService;
        private readonly ILogService<TournamentProvider> logService;

        public TournamentProvider(ITournamentClient tournamentClient, IDataService dataService, ILogService<TournamentProvider> logService)
        {
            if (tournamentClient == null || dataService == null)
            {
                throw new ArgumentNullException();
            }
            this.tournamentClient = tournamentClient;
            this.dataService = dataService;
            if (logService == null)
            {
                this.logService = new LogService<TournamentProvider>();
            }
            else
            {
                this.logService = logService;
            }
        }

        
        /*public bool AddTournament(Tournament tournament)
        {
            return tournamentClient.AddTournament(tournament);
        }

        public bool DeleteTournament(int tournamentId)
        {
            return tournamentClient.DeleteTournament(tournamentId);
        }*/

        public Tournament GetTournamentById(int tournamentId)
        {
            if (tournamentId <= 0)
            {
                logService.LogError("Class: TournamentProvider Method: GetTournamentById  tournamentId must be positive");
                throw new ArgumentOutOfRangeException("tournamentId must be positive");
            }
            return dataService.GetTournamentById(tournamentId);
        }

        /*public bool UpdateTournament(Tournament tournament)
        {
            return tournamentClient.UpdateTournament(tournament);
        }*/
    }
}
