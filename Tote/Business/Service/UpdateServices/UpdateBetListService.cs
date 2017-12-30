using System;
using Common.Models;
using Data.Clients;
using System.Collections.Generic;
using Business.Providers;
using Common.Logger;

namespace Business.Service
{
    public class UpdateBetListService : IUpdateBetListService
    {
        private readonly IBetListClient betListClient;
        private readonly IBetListProvider betListProvider;
        private readonly ILogService<UpdateBetListService> logService;
        public UpdateBetListService(IBetListClient betListClient, IBetListProvider betListProvider, ILogService<UpdateBetListService> logService)
        {
            if (betListClient == null|betListProvider==null)
            {
                throw new ArgumentNullException();
            }
            this.betListClient = betListClient;
            this.betListProvider = betListProvider;
            if (logService == null)
            {
                this.logService = new LogService<UpdateBetListService>();
            }
            else
            {
                this.logService = logService;
            }
        }

        public bool AddBasket(int matchId, int eventId, int userId)
        {
            if(matchId<=0||eventId<=0||userId<=0)
            {
                logService.LogError("Class: UpdateBetListService Method: AddBasket ArgumentOutOfRangeException");
                throw new ArgumentOutOfRangeException("Not positive Id not allowed");
            }
            Basket basket = new Basket()
            {
                MatchId = matchId,
                EventId = eventId,
                UserId = userId
            };
            return betListClient.AddBasket(basket);
        }

        public void AddBets(decimal amount, int userId)
        {
            if(amount<=0||userId<=0)
            {
                logService.LogError("Class: UpdateBetListService Method: AddBets ArgumentOutOfRangeException");
                throw new ArgumentOutOfRangeException("Not positive userId or amount not allowed");
            }
            int rateId = AddRate(amount, userId);
            if(rateId<=0)
            {
                logService.LogError("Class: UpdateBetListService Method: AddBets  AddRate rateId not positive");
                throw new ArgumentOutOfRangeException("Not positive userId or amount not allowed");
            }
            double total = 1;
            IReadOnlyList<Basket> baskets = betListProvider.GetBasketByUser(userId, out total);
            if (baskets == null)
            {
                logService.LogError("Class: UpdateBetListService Method: AddBets  GetBasketByUser is null");
                throw new NullReferenceException("Basket is null");
            }

            foreach (Basket basket in baskets)
            {
                Bet bet = new Bet()
                {
                    RateId = rateId,
                    MatchId = basket.MatchId,
                    Event = new Event { EventId = basket.EventId }
                };
                bool result = betListClient.AddBet(bet, basket.BasketId);
                if(result)
                {
                    logService.LogError("Class: UpdateBetListService Method: AddBets  AddBet don't add to DB");                    
                }
            }            
        }

        public bool AddBet(Bet bet, int basketId)
        {
            if(bet==null||basketId<=0)
            {
                logService.LogError("Class: UpdateBetListService Method: AddBet  AddBet don't add to DB");
                throw new NullReferenceException("Bet is null or basketId<=0");
            }
            return betListClient.AddBet(bet, basketId);
        }

        public int AddRate(decimal amount, int userId)
        {
            if (amount <= 0 || userId <= 0)
            {
                logService.LogError("Class: UpdateBetListService Method: AddRate  Rate don't add to DB");
                throw new ArgumentOutOfRangeException("amount<=0 or userId<=0");
            }
            Rate rate = new Rate()
            {
                Amount = amount,
                DateRate = DateTime.Now,
                UserId = userId
            };

            return betListClient.AddRate(rate);
        }

        public bool DeleteBasket(int basketId)
        {
            if (basketId <= 0)
            {
                logService.LogError("Class: UpdateBetListService Method: DeleteBasket Basket don't delete to DB");
                throw new ArgumentOutOfRangeException("amount<=0 or userId<=0");
            }
            return betListClient.DeleteBasket(basketId);               
        }
    }
}
