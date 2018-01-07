using Common.Models;
using Data.Business;
using Data.Clients;
using System.Collections.Generic;
using System;
using Common.Logger;

namespace Data.Services
{
    public class DataService : IDataService
    {
        private readonly IBetListClient betListClient;
        private readonly ITournamentClient tournamentClient;
        private readonly ITeamClient teamClient;
        private readonly IConvert convert;
        private readonly IMatchConvert matchConvert;
        private readonly IMatchService matchService;
        private readonly ISportService sportService;
        private readonly ILogService<DataService> logService;

        public DataService(IBetListClient betListClient, IConvert convert, ITournamentClient tournamentClient,
            ITeamClient teamClient, IMatchService matchService, ISportService sportService,
            IMatchConvert matchConvert, ILogService<DataService> logService)
        {
            if (betListClient == null|| convert==null|| tournamentClient==null||
                teamClient==null|| matchService==null || sportService == null || matchConvert == null)
            {
                throw new ArgumentNullException();
            }
            this.betListClient = betListClient;
            this.convert = convert;
            this.tournamentClient = tournamentClient;
            this.teamClient = teamClient;
            this.matchService = matchService;
            this.sportService = sportService;
            this.matchConvert = matchConvert;
            if (logService == null)
            {
                this.logService = new LogService<DataService>();
            }
            else
            {
                this.logService = logService;
            }
        }
        

        public IReadOnlyList<Match> GetBets(int? sportId, int? tournamentId)
        {
            
            var dto = betListClient.GetBets(sportId, tournamentId);

            if (dto != null)
            {
                return matchConvert.ToMatchList(dto);
            }
            logService.LogError("Class: DataService Method: GetBets List<Match> is null");
            return new List<Match>();
        }

        public IReadOnlyList<Match> GetBetsAll()
        {
            var dto = betListClient.GetBetsAll();

            if (dto != null)
            {
                return matchConvert.ToMatchList(dto);
            }
            logService.LogError("Class: DataService Method: GetBetsAll List<Match> is null");
            return new List<Match>();
            
        }

        public IReadOnlyList<Event> GetEvents()
        {
            var dto = betListClient.GetEvents();

            if (dto != null)
            {
                return convert.ToEvents(dto);
            }
            logService.LogError("Class: DataService Method: GetEvents List<Event> is null");
            return new List<Event>();
        }

        public IReadOnlyList<Event> GetEvents(int id)
        {
            var dto = betListClient.GetEvents(id);

            if (dto != null)
            {
                return convert.ToEvents(dto);
            }
            logService.LogError("Class: DataService Method: GetEvents List<Event> is null");
            return new List<Event>();
        }
        
        
        public IReadOnlyList<Basket> GetBasketByUser(int userId, out double total)
        {
            total = 1;
            if(userId<=0)
            {                
                logService.LogError("Class: DataService Method: GetBasketByUser userId is not positive");
                return new List<Basket>();
            }            
            var basketsDto = betListClient.GetBasketByUser(userId);
            var baskets = convert.ToBasket(basketsDto);
            var basketsMatch = new List<Basket>();
            foreach(var basket in baskets)
            {                
                var match = matchService.GetMatchById(basket.MatchId);
                if (match.Date < DateTime.Now)
                {
                    betListClient.DeleteBasket(basket.BasketId);
                    continue;
                }
                var _events = matchService.GetEventsByMatch(basket.MatchId);
                var sport = sportService.GetSport(match.SportId);                
                match.SportName = sport.Name;

                foreach(var _event in _events )
                {
                    if(_event.EventId== basket.EventId)
                    {
                        match.Events = new List<Event>();
                        match.Events.Add(_event);
                        total *= _event.Coefficient;                 
                    }
                }
                basket.Match=match;
                basketsMatch.Add(basket);
                
            }
            if(basketsMatch != null)
            {
                return basketsMatch;
            }
            logService.LogError("Class: DataService Method: GetBasketByUser List<Basket> is null");
            return new List<Basket>();
        }

        public Basket GetBasketById(int basketId, int userId)
        {
            var basketDto = betListClient.GetBasketById(basketId, userId);
            var basket = convert.ToBasket(basketDto);
            var basketMatch = new Basket();

            var match = matchService.GetMatchById(basket.MatchId);
            var _events = matchService.GetEventsByMatch(basket.MatchId);

            foreach (var _event in _events)
            {
                if (_event.EventId == basket.EventId)
                {
                    match.Events = new List<Event>();
                    match.Events.Add(_event);
                }
            }
            basket.Match = match;
            basketMatch = basket;


            if (basketMatch != null)
            {
                return basketMatch;
            }
            logService.LogError("Class: DataService Method: GetBasketById Basket is null");
            return new Basket();
        }

        public IReadOnlyList<Rate> GetRateByUserId(int userId)
        {
            var dto = betListClient.GetRateByUserId(userId);

            if (dto != null)
            {
                return convert.ToRate(dto);
            }
            logService.LogError("Class: DataService Method: GetRateByUserId List<Rate> is null");
            return new List<Rate>();
        }

        public IReadOnlyList<Bet> GetBetByRateId(int rateId, out double total)
        {
            total = 1;   
            var betsDto = betListClient.GetBetByRateId(rateId);
            var bets= convert.ToBet(betsDto);
            var betsRate = new List<Bet>();
            foreach(var bet in bets)
            {
                var match = matchService.GetMatchById(bet.MatchId);
                var _events = matchService.GetEventsByMatch(bet.MatchId);

                foreach (var _event in _events)
                {
                    if (_event.EventId == bet.Event.EventId)
                    {
                        match.Events = new List<Event>();
                        match.Events.Add(_event);
                        total *= _event.Coefficient;                     
                    }
                }
                bet.Match = match;
                betsRate.Add(bet);
            }

            if (betsRate != null)
            {
                return betsRate;
            }
            logService.LogError("Class: DataService Method: GetBetByRateId List<Bet> is null");
            return new List<Bet>();
        }

        
    }
}
