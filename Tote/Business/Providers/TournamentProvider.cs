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
        

        public Tournament GetTournamentById(int tournamentId)
        {
            if (tournamentId <= 0)
            {
                logService.LogError("Class: TournamentProvider Method: GetTournamentById  tournamentId must be positive");
                return null;
            }
            return dataService.GetTournamentById(tournamentId);
        }
        
    }
}
