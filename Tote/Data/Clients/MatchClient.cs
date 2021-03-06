﻿using System.Collections.Generic;
using Common.Models;
using Data.TeamService;
using Data.Business;
using System.ServiceModel;
using System;

namespace Data.Clients
{
    public class MatchClient : IMatchClient
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MatchClient));
        private readonly IMatchConvert convert;

        public MatchClient(IMatchConvert convert)
        {
            this.convert = convert;
        }

        public bool AddEvent(IReadOnlyList<Event> events)
        {            
            var eventsDto = convert.ToEventDto(events);
            var model = new bool();
            using (var client = new TeamService.EventServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.AddEvents(eventsDto);
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

        public bool AddMatch(Match match)
        {
            var matchDto = new MatchDto();
            matchDto = convert.ToMatchDto(match);
            var model = new bool();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.AddMatch(matchDto);
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

        public bool DeleteEvent(int matchId)
        {
            var model = new bool();
            using (var client = new TeamService.EventServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.DeleteEvents(matchId);
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

        public bool DeleteMatch(int matchId)
        {
            var model = new bool();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.DeleteMatch(matchId);
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

        public IReadOnlyList<EventDto> GetEventByMatch(int matchId)
        {
            var model = new List<EventDto>();
            using (var client = new TeamService.EventServiceClient())
            {
                try
                {
                    client.Open();
                    var events = client.GetEvents(matchId);
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

        public MatchDto GetMatchById(int matchId)
        {
            var model = new MatchDto();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.GetMatchById(matchId);
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

        public IReadOnlyList<SortDto> GetMatchBySportDateStatus(int sportId, string dateMatch, int status)
        {
            var model = new List<SortDto>();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    var matches = client.GetMatchBySportDateStatus(sportId, dateMatch, status);
                    foreach (var match in matches)
                    {
                        model.Add(match);
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

        public IReadOnlyList<MatchDto> GetMatchesAll()
        {
            var model = new List<MatchDto>();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    var matches = client.GetMatchesAll();
                    foreach (var match in matches)
                    {
                        model.Add(match);
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

        public IReadOnlyList<ResultDto> GetResultsAll()
        {
            var model = new List<ResultDto>();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    var results = client.GetResultsAll();
                    foreach (var result in results)
                    {
                        model.Add(result);
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

        public bool UpdateEvent(Event[] events)
        {
            var eventsDto = convert.ToEventDto(events);
            var model = new bool();
            using (var client = new TeamService.EventServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.UpdateEvents(eventsDto);
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

        public bool UpdateMatch(Match match)
        {
            var matchDto = new MatchDto();
            matchDto = convert.ToMatchDto(match);
            var model = new bool();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.UpdateMatch(matchDto);
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
