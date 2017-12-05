using Common.Models;
using Data.Services;
using System.Collections.Generic;
using System;
using Data.Clients;

namespace Business.Providers
{
    public class BetListProvider : IBetListProvider
    {
        private readonly IDataService dataService;
        private readonly IBetListClient betListClient;
        public BetListProvider(IDataService dataService, IBetListClient betListClient)
        {
            this.dataService = dataService;
            this.betListClient = betListClient;
        }

        public bool AddSport(Sport sport)
        {
            return betListClient.AddSport(sport);
        }

        public bool DeleteSport(int sportId)
        {
            return betListClient.DeleteSport(sportId);
        }

        public IReadOnlyList<Match> GetBetAll()
        {
            return dataService.GetBetsAll();
        }

        public IReadOnlyList<Match> GetBetList(int? sportId, int? tournamentId)
        {
            return dataService.GetBets(sportId, tournamentId);
        }

        public IReadOnlyList<Event> GetEvents()
        {
            return dataService.GetEvents();
        }

        public IReadOnlyList<Event> GetEvents(int id)
        {
            return dataService.GetEvents(id);
        }

        public IReadOnlyList<Match> GetMatchesAll()
        {
            return dataService.GetMatchesAll();
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

        public bool UpdateSport(Sport sport)
        {
            return betListClient.UpdateSport(sport);
        }
    }
}
