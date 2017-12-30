using System.Collections.Generic;
using Common.Models;
using Data.TeamService;
using Data.Business;
using System.ServiceModel;
using System;
using log4net;
using Common.Logger;

namespace Data.Clients
{
    public class MatchClient : IMatchClient
    {
        private readonly IMatchConvert convert;
        private readonly ILogService<MatchClient> logService;

        public MatchClient(IMatchConvert convert):this(convert, new LogService<MatchClient>())
        {

        }

        public MatchClient(IMatchConvert convert, ILogService<MatchClient> logService)
        {
            if (convert == null)
            {
                throw new ArgumentNullException();
            }
            this.convert = convert;
            if (logService == null)
            {
                this.logService = new LogService<MatchClient>();
            }
            else
            {
                this.logService = logService;
            }
        }
       
        public bool AddEvent(IReadOnlyList<Event> events)
        {
            if (events == null)
            {
                logService.LogError("Class: MatchClient Method:AddEvent events is null");
                return false;
            }
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

        public bool AddMatch(Match match)
        {
            if (match == null)
            {
                logService.LogError("Class: MatchClient Method:AddMatch match is null");
                return false;
            }
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

        public bool DeleteEvent(int matchId)
        {
            if (matchId <= 0)
            {
                logService.LogError("Class: MatchClient Method: DeleteEvent matchId is not positive");
                return false;
            }
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

        public bool DeleteMatch(int matchId)
        {
            if (matchId <= 0)
            {
                logService.LogError("Class: MatchClient Method: DeleteMatch matchId is not positive");
                return false;
            }
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

        public IReadOnlyList<EventDto> GetEventByMatch(int matchId)
        {
            if (matchId <= 0)
            {
                logService.LogError("Class: MatchClient Method: GetEventByMatch matchId is not positive");
                return null;
            }
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

        public MatchDto GetMatchById(int matchId)
        {
            if (matchId <= 0)
            {
                logService.LogError("Class: MatchClient Method: GetMatchById matchId is not positive");
                return null;
            }
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

        public IReadOnlyList<SortDto> GetMatchBySportDateStatus(int sportId, string dateMatch, int status)
        {
            if (sportId < 0||status<0||status>3)
            {
                logService.LogError("Class: MatchClient Method: GetMatchBySportDateStatus sportId is not positive or status must be in the interval [0;3]");
                return null;
            }
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

        public bool UpdateEvent(Event[] events)
        {
            if (events == null )
            {
                logService.LogError("Class: MatchClient Method: GetMatchBySportDateStatus events is null");
                return false;
            }
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

        public bool UpdateMatch(Match match)
        {
            if (match == null)
            {
                logService.LogError("Class: MatchClient Method: GetMatchBySportDateStatus match is null");
                return false;
            }
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
    }
}
