using Common.Models;
using Data.Services;
using System.Collections.Generic;
using System;
using Data.Clients;
using Common.Logger;

namespace Business.Providers
{
    public class BetListProvider : IBetListProvider
    {
        private readonly IDataService dataService;
        private readonly IBetListClient betListClient;
        private readonly ILogService<BetListProvider> logService;
        public BetListProvider(IDataService dataService, IBetListClient betListClient, ILogService<BetListProvider> logService)
        {
            if (dataService == null || betListClient == null)
            {
                throw new ArgumentNullException();
            }
            this.dataService = dataService;
            this.betListClient = betListClient;
            if (logService == null)
            {
                this.logService = new LogService<BetListProvider>();
            }
            else
            {
                this.logService = logService;
            }
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
            if (id <= 0)
            {
                logService.LogError("Class: BetListProvider Method: GetEvents  ID can not negative");
                throw new ArgumentOutOfRangeException("ID can not negative");
            }
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

        /*public bool UpdateSport(Sport sport)
        {
            return betListClient.UpdateSport(sport);
        }

        public bool AddBasket(Basket basket)
        {
            return betListClient.AddBasket(basket);
        }

        public bool DeleteBasket(int basketId)
        {
            return betListClient.DeleteBasket(basketId);
        }*/

        public IReadOnlyList<Basket> GetBasketByUser(int userId, out double total)
        {
            if (userId <= 0)
            {
                logService.LogError("Class: BetListProvider Method: GetBasketByUser  userID can not negative");
                throw new ArgumentOutOfRangeException("userID can not negative");
            }            
            return dataService.GetBasketByUser(userId, out total);
        }

        /*public IReadOnlyList<Match> GetMatchesByBasket(int userId)
        {
            throw new NotImplementedException();
        }*/

        public Basket GetBasketById(int basketId, int userId)
        {
            if (userId <= 0|| basketId <= 0)
            {
                logService.LogError("Class: BetListProvider Method: GetBasketById  userID or basketId can not negative");
                throw new ArgumentOutOfRangeException("userID or basketId can not negative");
            }
            return dataService.GetBasketById(basketId, userId);
        }

        /*public bool AddBet(Bet bet, int basketId)
        {
            return betListClient.AddBet(bet, basketId);
        }

        public int AddRate(Rate rate)
        {
            return betListClient.AddRate(rate);
        }*/

        public IReadOnlyList<Rate> GetRateByUserId(int userId)
        {
            if (userId <= 0)
            {
                logService.LogError("Class: BetListProvider Method: GetRateByUserId  userID can not negative");
                throw new ArgumentOutOfRangeException("userID can not negative");
            }
            return dataService.GetRateByUserId(userId);
        }

        public IReadOnlyList<Bet> GetBetByRateId(int rateId, out double total)
        {
            if (rateId <= 0)
            {
                logService.LogError("Class: BetListProvider Method: GetBetByRateId  rateId can not negative");
                throw new ArgumentOutOfRangeException("rateId can not negative");
            }
            return dataService.GetBetByRateId(rateId, out total);
        }

        public IReadOnlyList<Tournament> GetTournamentesByTeamId(int teamId)
        {
            if (teamId <= 0)
            {
                logService.LogError("Class: BetListProvider Method: GetTournamentesByTeamId  teamId can not negative");
                throw new ArgumentOutOfRangeException("teamId can not negative");
            }
            return dataService.GetTournamentesByTeamId(teamId);
        }

        public Tournament GetTournamentById(int tournamentId)
        {
            if (tournamentId <= 0)
            {
                logService.LogError("Class: BetListProvider Method: GetTournamentById  tournamentId can not negative");
                throw new ArgumentOutOfRangeException("tournamentId can not negative");
            }
            return dataService.GetTournamentById(tournamentId);
        }
    }
}
