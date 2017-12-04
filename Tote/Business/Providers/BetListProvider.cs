using Common.Models;
using Data.Services;
using System.Collections.Generic;
using System;

namespace Business.Providers
{
    public class BetListProvider : IBetListProvider
    {
        private readonly IDataService dataService;
        public BetListProvider(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public IReadOnlyList<Bet> GetBetAll()
        {
            return dataService.GetBetsAll();
        }

        public IReadOnlyList<Bet> GetBetList(int? sportId, int? tournamentId)
        {
            return dataService.GetBets(sportId, tournamentId);
        }

        public Sport GetSport(int? id)
        {
            return dataService.GetSport(id);
        }

        public IReadOnlyList<Sport> GetSports()
        {
            return dataService.GetSports();
        }

        public IReadOnlyList<Tournament> GetTournament(int? sportId)
        {
            return dataService.GetTournament(sportId);
        }

        public IReadOnlyList<Tournament> GetTournamentes()
        {
            return dataService.GetTournamentes();
        }
    }
}
