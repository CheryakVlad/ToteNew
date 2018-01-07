using System;
using System.Collections.Generic;
using Common.Models;
using Data.Clients;
using Data.Business;
using Common.Logger;

namespace Data.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchClient matchClient;
        private readonly IMatchConvert convert;
        private readonly ILogService<MatchService> logService;

        public MatchService(IMatchClient matchClient, IMatchConvert convert, ILogService<MatchService> logService)
        {
            if (matchClient == null || convert == null)
            {
                throw new ArgumentNullException();
            }
            this.matchClient = matchClient;
            this.convert = convert;
            if (logService == null)
            {
                this.logService = new LogService<MatchService>();
            }
            else
            {
                this.logService = logService;
            }
        }
        
        
        public Match GetMatchById(int matchId)
        {
            var dto = matchClient.GetMatchById(matchId);

            if (dto != null)
            {
                return convert.ToMatch(dto);
            }
            logService.LogError("Class: MatchService Method: GetMatchById Match is null");
            return new Match();
        }

        public IReadOnlyList<Match> GetMatchsAll()
        {
            var dto = matchClient.GetMatchesAll();

            if (dto != null)
            {
                return convert.ToMatches(dto);
            }
            logService.LogError("Class: MatchService Method: GetMatchsAll List<Match> is null");
            return new List<Match>();
        }

        public IReadOnlyList<Match> GetMatchBySportDateStatus(int sportId, string dateMatch, int status)
        {
            if (sportId < 0 || status < 0 || status > 3)
            {
                logService.LogError("Class: MatchService Method: GetMatchBySportDateStatus sportId is not positive or status must be in the interval [0;3]");
                return null;
            }
            var dto = matchClient.GetMatchBySportDateStatus(sportId, dateMatch, status);

            if (dto != null)
            {
                return convert.ToMatches(dto);
            }
            logService.LogError("Class: MatchService Method: GetMatchBySportDateStatus List<Match> is null");
            return new List<Match>().ToArray();
        }

        public IReadOnlyList<Result> GetResultsAll()
        {
            var dto = matchClient.GetResultsAll();

            if (dto != null)
            {
                return convert.ToResult(dto);
            }
            logService.LogError("Class: MatchService Method: GetResultsAll List<Result> is null");
            return new List<Result>();
        }

        public IReadOnlyList<Event> GetEventsByMatch(int matchId)
        {
            var dto = matchClient.GetEventByMatch(matchId);

            if (dto != null)
            {
                return convert.ToEvent(dto);
            }
            logService.LogError("Class: MatchService Method: GetEventsByMatch List<Event> is null");
            return new List<Event>();
        }

        public Match GetMatchWithEvents(int matchId)
        {
            var matchDto = matchClient.GetMatchById(matchId);
            var eventsDto = matchClient.GetEventByMatch(matchId);

            if (matchDto != null && eventsDto != null)
            {
                var match = convert.ToMatch(matchDto);
                var events = convert.ToEvent(eventsDto);
                match.Events = new List<Event>();                
                foreach (var _event in events)
                {
                    match.Events.Add(_event);
                }
                return match;
            }
            logService.LogError("Class: MatchService Method: GetMatchById Match is null");
            return new Match();
        }
    }
}
