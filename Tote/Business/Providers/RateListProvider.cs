using Common.Models;
using Data.Services;
using System.Collections.Generic;
using System;

namespace Business.Providers
{
    public class RateListProvider : IRateListProvider
    {
        private IDataService dataService;
        public RateListProvider(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public IList<Bet> GetRateAll()
        {
            return dataService.GetRatesAll();
        }

        public IList<Bet> GetRateList(int? sportId, int? tournamentId)
        {
            return dataService.GetRates(sportId, tournamentId);
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
