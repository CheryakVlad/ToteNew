
using System.Collections.Generic;
using Data.ToteService;
using System.ServiceModel;
using System.Data.SqlClient;
using System;
using Common.Models;
using Data.Business;

namespace Data.Clients
{
    public class BetListClient : IBetListClient
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BetListClient));
        private readonly IConvert convert;

        public BetListClient(IConvert convert)
        {
            this.convert = convert;
        }

        public bool AddBasket(Basket basket)
        {
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
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }
            }
            return model;
        }

        public bool AddBet(Bet bet, int basketId)
        {
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
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public int AddRate(Rate rate)
        {
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
                    log.Error(customEx.Message);
                    return 0;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return 0;
                }
                catch(ArgumentOutOfRangeException argEx)
                {
                    log.Error(argEx.Message);
                    return 0;
                }

            }
            return model;
        }

        public bool AddSport(Sport sport)
        {
            var sportDto = new SportDto();
            sportDto = convert.ToSportDto(sport);
            var model = new bool();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.AddSport(sportDto);
                    client.Close();
                }
                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool DeleteBasket(int basketId)
        {
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
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }
            }
            return model;
        }

        public bool DeleteSport(int sportId)
        {
            var model = new bool();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.DeleteSport(sportId);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public BasketDto GetBasketById(int basketId, int userId)
        {
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }
            }
            return model;
        }

        public IReadOnlyList<BasketDto> GetBasketByUser(int userId)
        {
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }
            }

            return model;
        }

        public IReadOnlyList<BetDto> GetBetByRateId(int rateId)
        {
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }

            }
            return model;
        }

        public IReadOnlyList<BetListDto> GetBets(int? sportId, int? tournamentId)
        {
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch(CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }

            }
            return model;
        }

        public IReadOnlyList<EventDto> GetEvents(int id)
        {
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }

            }
            return model;
        }

        public IReadOnlyList<RateDto> GetRateByUserId(int userId)
        {
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }

            }
            return model;
        }        

        public SportDto GetSport(int? id)
        {
            var model = new SportDto();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.GetSport(id);
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                }
                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }

            }

            return model;
        }

        public IReadOnlyList<SportDto> GetSports()
        {
            var model = new List<SportDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();

                    var sports = client.GetSports();
                    foreach (var sport in sports)
                    {
                        model.Add(sport);
                    }
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                }
                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }

            }

            return model;
        }

        public IReadOnlyList<TournamentDto> GetTournament(int? sportId)
        {
            var model = new List<TournamentDto>();
            using (var client = new ToteService.TournamentServiceClient())
            {
                try
                {
                    client.Open();

                    var tournaments = client.GetTournament(sportId);
                    foreach (var tournament in tournaments)
                    {
                        model.Add(tournament);
                    }
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                }
                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }

            }

            return model;
        }

        public IReadOnlyList<TournamentDto> GetTournamentes()
        {
            var model = new List<TournamentDto>();
            using (var client = new ToteService.TournamentServiceClient())
            {
                try
                {
                    client.Open();

                    var tournaments = client.GetTournamentes();
                    foreach (var tournament in tournaments)
                    {
                        model.Add(tournament);
                    }
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                }
                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }
            }

            return model;
        }

        public bool UpdateSport(Sport sport)
        {
            var sportDto = new SportDto();
            sportDto = convert.ToSportDto(sport);
            var model = new bool();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.UpdateSport(sportDto);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }
    }
}
