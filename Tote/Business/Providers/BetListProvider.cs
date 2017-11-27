using Common.Models;
using Data.Services;
using System.Collections.Generic;
using System;

namespace Business.Providers
{
    public class BetListProvider : IBetListProvider
    {
        private IDataService dataService;
        public BetListProvider(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public IList<Bet> GetBetAll()
        {
            return dataService.GetBetsAll();
        }

        public IList<Bet> GetBetList(int? sportId, int? tournamentId)
        {
            return dataService.GetBets(sportId, tournamentId);
        }

        public Sport GetSport(int? id)
        {
            return dataService.GetSport(id);
        }

        public IList<Sport> GetSports()
        {
            return dataService.GetSports();
        }

        public IList<Tournament> GetTournament(int? sportId)
        {
            return dataService.GetTournament(sportId);
        }

        public IList<Tournament> GetTournamentes()
        {
            return dataService.GetTournamentes();
        }
    }
}
