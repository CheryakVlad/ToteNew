using System.Collections.Generic;
using Data.ToteService;
using System.ServiceModel;
using System;
using Common.Models;
using Data.Business;
using Common.Logger;

namespace Data.Clients
{
    public class BetListClient : IBetListClient
    {
        private readonly IConvert convert;
        private readonly ILogService<BetListClient> logService;

        public BetListClient(IConvert convert):this(convert, new LogService<BetListClient>())
        {
            
        }

        public BetListClient(IConvert convert, ILogService<BetListClient> logService)
        {
            if (convert == null)
            {
                throw new ArgumentNullException();
            }
            this.convert = convert;
            if (logService == null)
            {
                this.logService = new LogService<BetListClient>();
            }
            else
            {
                this.logService = logService;
            }
        }        

        public bool AddBasket(Basket basket)
        {
            if (basket == null)
            {
                logService.LogError("Class: BetListClient Method:AddBasket Basket is null");
                return false; 
            }
            var basketDto = new BasketDto();
            basketDto = convert.ToBasketDto(basket);
            var model = new bool();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.AddBasket(basketDto);
                    client.Close();
                }
                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }
            }
            return model;
        }

        public bool AddBet(Bet bet, int basketId)
        {
            if (bet == null||basketId<=0)
            {
                logService.LogError("Class: BetListClient Method: AddBet Bet is null or basketId is not positive");
                return false;
            }
            var betDto = new BetDto();
            betDto = convert.ToBetDto(bet);
            var model = new bool();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.AddBet(betDto, basketId);
                    client.Close();
                }
                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public int AddRate(Rate rate)
        {
            if (rate == null)
            {
                logService.LogError("Class: BetListClient Method: AddRate Rate is null");
                return 0;
            }
            var rateDto = new RateDto();
            rateDto = convert.ToRateDto(rate);
            var model = new int();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.GetRateIdAfterAdd(rateDto);
                    if(model<=0)
                    { 
                        throw new ArgumentOutOfRangeException("Not positive number not allowed");
                    }
                    client.Close();
                }
                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return 0;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return 0;
                }
                catch(ArgumentOutOfRangeException argEx)
                {
                    logService.LogError(argEx.Message);
                    return 0;
                }

            }
            return model;
        }        

        public bool DeleteBasket(int basketId)
        {
            if (basketId <= 0)
            {
                logService.LogError("Class: BetListClient Method: DeleteBasket basketId is not positive");
                return false;
            }
            var model = new bool();            
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.DeleteBasket(basketId);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }
            }
            return model;
        }


        public BasketDto GetBasketById(int basketId, int userId)
        {
            if (basketId <= 0|| userId<=0)
            {
                logService.LogError("Class: BetListClient Method: DeleteBasket basketId or userId is not positive");
                return null;
            }
            var model = new BasketDto();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.GetBasketById(basketId, userId);
                    if(model==null)
                    {
                        throw new NullReferenceException();
                    }
                    client.Close();
                }
                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }
            }
            return model;
        }

        public IReadOnlyList<BasketDto> GetBasketByUser(int userId)
        {
            if (userId <= 0)
            {
                logService.LogError("Class: BetListClient Method: DeleteBasket userId is not positive");
                return null;
            }
            var model = new List<BasketDto>();            
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    var baskets = client.GetBasketByUser(userId);
                    foreach (var basket in baskets)
                    {
                        model.Add(basket);                        
                    }
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }

                }
                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }
            }

            return model;
        }

        public IReadOnlyList<BetDto> GetBetByMatchId(int matchId)
        {
            if (matchId <= 0)
            {
                logService.LogError("Class: BetListClient Method: DeleteBasket rateId is not positive");
                return null;
            }
            var model = new List<BetDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();

                    var bets = client.GetBetByMatchId(matchId);
                    foreach (var bet in bets)
                    {
                        model.Add(bet);
                    }
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }

            }
            return model;
        }

        public IReadOnlyList<BetDto> GetBetByRateId(int rateId)
        {
            if (rateId <= 0)
            {
                logService.LogError("Class: BetListClient Method: DeleteBasket rateId is not positive");
                return null;
            }
            var model = new List<BetDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();

                    var rates = client.GetBetByRateId(rateId);
                    foreach (var rate in rates)
                    {
                        model.Add(rate);
                    }
                    client.Close();
                    if(model==null)
                    {
                        throw new NullReferenceException();
                    }
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }

            }
            return model;
        }

        public IReadOnlyList<BetListDto> GetBets(int? sportId, int? tournamentId)
        {
            if (sportId < 0 || tournamentId < 0)
            {
                logService.LogError("Class: BetListClient Method: GetBets sportId or tournamentId is not positive");
                return null;
            }
            var model = new List<BetListDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    var bets = client.GetBets(sportId, tournamentId);
                    foreach (var bet in bets)
                    {
                        model.Add(bet);
                    }
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }

                }
                catch(FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch(CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }
            }

            return model;
        }

        public IReadOnlyList<BetListDto> GetBetsAll()
        {
            var model = new List<BetListDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();

                    var bets = client.GetBetsAll();
                    foreach (var bet in bets)
                    {
                        model.Add(bet);
                    }
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }

                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }

            }
            return model;
        }

        public IReadOnlyList<EventDto> GetEvents()
        {
            var model = new List<EventDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();

                    var events = client.GetEventsAll();
                    foreach (var _event in events)
                    {
                        model.Add(_event);
                    }
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }

            }
            return model;
        }

        public IReadOnlyList<EventDto> GetEvents(int id)
        {
            if (id <= 0)
            {
                logService.LogError("Class: BetListClient Method: DeleteBasket id is not positive");
                return null;
            }
            var model = new List<EventDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();

                    var events = client.GetEvents(id);
                    foreach (var _event in events)
                    {
                        model.Add(_event);
                    }
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }

            }
            return model;
        }

        public IReadOnlyList<RateDto> GetRateByUserId(int userId)
        {
            if (userId <= 0)
            {
                logService.LogError("Class: BetListClient Method: DeleteBasket userId is not positive");
                return null;
            }
            var model = new List<RateDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();

                    var rates = client.GetRateByUserId(userId);
                    foreach (var rate in rates)
                    {
                        model.Add(rate);
                    }
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }

            }
            return model;
        }  
    }
}
