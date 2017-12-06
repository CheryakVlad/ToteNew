
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
                
                //log/ null vernut
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

            }
            return model;
        }

       /* public IReadOnlyList<BetListDto> GetMatch(int id)
        {
            var model = new List<BetListDto>();
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

            }
            return model;
        }*/

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
