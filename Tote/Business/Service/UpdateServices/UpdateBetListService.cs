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
                return false;
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
                return;
            }
            int rateId = AddRate(amount, userId);
            if(rateId<=0)
            {
                logService.LogError("Class: UpdateBetListService Method: AddBets  AddRate rateId not positive");
                return;
            }
            double total = 1;
            IReadOnlyList<Basket> baskets = betListProvider.GetBasketByUser(userId, out total);
            if (baskets == null)
            {
                logService.LogError("Class: UpdateBetListService Method: AddBets  GetBasketByUser is null");
                return;
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
                return false;
            }
            return betListClient.AddBet(bet, basketId);
        }

        public int AddRate(decimal amount, int userId)
        {
            if (amount <= 0 || userId <= 0)
            {
                logService.LogError("Class: UpdateBetListService Method: AddRate  Rate don't add to DB");
                return 0;
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
                return false;
            }
            return betListClient.DeleteBasket(basketId);               
        }
    }
}
