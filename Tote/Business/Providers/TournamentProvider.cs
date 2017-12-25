using System;
using Common.Models;
using Data.Clients;
using Data.Services;

namespace Business.Providers
{
    public class TournamentProvider : ITournamentProvider
    {
        
        private readonly ITournamentClient tournamentClient;
        private readonly IDataService dataService;
        public TournamentProvider(ITournamentClient tournamentClient, IDataService dataService)
        {
            this.tournamentClient = tournamentClient;
            this.dataService = dataService;
        }

        public static TournamentProvider createTournamentProvider(ITournamentClient tournamentClient, IDataService dataService)
        {
            if (tournamentClient == null || dataService == null)
            {
                throw new ArgumentNullException();
            }
            return new TournamentProvider(tournamentClient, dataService);
        }

        public bool AddTournament(Tournament tournament)
        {
            return tournamentClient.AddTournament(tournament);
        }

        public bool DeleteTournament(int tournamentId)
        {
            return tournamentClient.DeleteTournament(tournamentId);
        }

        public Tournament GetTournamentById(int tournamentId)
        {
            return dataService.GetTournamentById(tournamentId);
        }

        public bool UpdateTournament(Tournament tournament)
        {
            return tournamentClient.UpdateTournament(tournament);
        }
    }
}
