using System.Collections.Generic;
using Common.Models;
using Data.TeamService;
using Data.ToteService;
using Data.UserService;

namespace Data.Business
{
    public class Convert : IConvert
    {
        public IReadOnlyList<Event> GetEvents(IReadOnlyList<ToteService.EventDto> eventsDto)
        {
            if (eventsDto.Count == 0)
            {
                return null;
            }
            var eventsList = new List<Event>();
            foreach (var eventDto in eventsDto)
            {                
                var _event = new Event
                {
                    EventId=eventDto.EventId,
                    Name=eventDto.Name,
                    Coefficient=eventDto.Coefficient,
                    MatchId=eventDto.MatchId
                };

                eventsList.Add(_event);
            }
            return eventsList;
        }

        public Basket ToBasket(BasketDto basketDto)
        {
            if (basketDto == null)
            {
                return null;
            }
            var basket = new Basket
            {
                BasketId = basketDto.BasketId,
                UserId = basketDto.UserId,
                MatchId = basketDto.MatchId,
                EventId = basketDto.EventId
            };

            return basket;
        }

        public IReadOnlyList<Basket> ToBasket(IReadOnlyList<BasketDto> basketsDto)
        {
            if (basketsDto.Count == 0)
            {
                return null;
            }
            var baskets = new List<Basket>();
            foreach (var basketDto in basketsDto)
            {
                var basket = ToBasket(basketDto);
                baskets.Add(basket);
            }

            return baskets;
        }

        public BasketDto ToBasketDto(Basket basket)
        {
            if (basket == null)
            {
                return null;
            }
            var basketDto = new BasketDto
            {
                BasketId = basket.BasketId,
                UserId = basket.UserId,
                Login=basket.Login,
                MatchId = basket.MatchId,
                EventId = basket.EventId
            };

            return basketDto;
        }

        public IReadOnlyList<Bet> ToBet(IReadOnlyList<BetDto> betsDto)
        {
            if (betsDto.Count == 0)
            {
                return null;
            }
            var bets = new List<Bet>();
            
            foreach (var betDto in betsDto)
            {
                var bet = ToBet(betDto);
                bets.Add(bet);
            }

            return bets;
        }

        public Bet ToBet(BetDto betDto)
        {
            if (betDto == null)
            {
                return null;
            }
            var bet = new Bet
            {
                BetId =betDto.BetId,
                MatchId=betDto.MatchId,
                RateId=betDto.RateId,
                Status=betDto.Status,
                Event=new Event() { EventId=betDto.EventId},
                Sport=new Sport() { Name=betDto.Sport },
                Tournament=new Tournament() { Name=betDto.Tournament}
            };

            return bet;
        }

        public BetDto ToBetDto(Bet bet)
        {
            if (bet == null)
            {
                return null;
            }
            var betDto = new BetDto
            {
                BetId=bet.BetId,
                EventId=bet.Event.EventId,
                MatchId=bet.MatchId,
                RateId=bet.RateId,
                Status=bet.Status
            };

            return betDto;
        }

        public IReadOnlyList<Bet> ToBetsList(IReadOnlyList<BetListDto> betsListDto)
        {
            if (betsListDto.Count == 0)
            {
                return null;
            }
            var betsList = new List<Bet>();
            foreach (var betListDto in betsListDto)
            {
                var teams = new List<Team>();
                teams.Add(new Team { Name = betListDto.CommandHome, Country = new Country { Name = betListDto.CountryHome } });
                teams.Add(new Team { Name = betListDto.CommandGuest, Country = new Country { Name = betListDto.CountryGuest } });
                var betList = new Bet
                {
                    BetId = betListDto.BetId,
                    WinCommandHome = betListDto.WinCommandHome,
                    WinCommandGuest = betListDto.WinCommandGuest,
                    Draw = betListDto.Draw,
                    Match = new Match { Date = System.Convert.ToDateTime(betListDto.Date), Teams=teams }
                    
                };

                betsList.Add(betList);
            }

            return betsList;
        }

        
        public IReadOnlyList<Event> ToEvents(IReadOnlyList<ToteService.EventDto> eventsDto)
        {
            if (eventsDto.Count == 0)
            {
                return null;
            }
            var eventsList = new List<Event>();
            foreach (var eventDto in eventsDto)
            {
                var _event = new Event
                {
                    EventId = eventDto.EventId,
                    Name = eventDto.Name,
                    Coefficient = eventDto.Coefficient,
                    MatchId = eventDto.MatchId
                };

                eventsList.Add(_event);
            }
            return eventsList;
        }               

        public IReadOnlyList<Rate> ToRate(IReadOnlyList<RateDto> ratesDto)
        {
            if (ratesDto.Count == 0)
            {
                return null;
            }
            var rates = new List<Rate>();
            foreach (var rateDto in ratesDto)
            {
                rates.Add(ToRate(rateDto));
            }
            return rates;
        }

        public Rate ToRate(RateDto rateDto)
        {
            if (rateDto == null)
            {
                return null;
            }
            var Rate = new Rate
            {
                RateId=rateDto.RateId,
                DateRate=rateDto.DateRate,
                Amount=rateDto.Amount,
                UserId=rateDto.UserId,
                Status=rateDto.Status
            };

            return Rate;
        }

        public RateDto ToRateDto(Rate rate)
        {
            if (rate == null)
            {
                return null;
            }
            var rateDto = new RateDto
            {
                RateId=rate.RateId,
                Amount=rate.Amount,
                DateRate=rate.DateRate,
                UserId=rate.UserId
            };

            return rateDto;
        }        
                       
    }
}
