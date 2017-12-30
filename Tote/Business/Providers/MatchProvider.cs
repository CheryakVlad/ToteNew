using System;
using System.Collections.Generic;
using Common.Models;
using Data.Services;
using Data.Clients;
using Common.Logger;

namespace Business.Providers
{
    public class MatchProvider : IMatchProvider
    {
        private readonly IMatchClient matchClient;
        private readonly IMatchService matchService;
        private readonly IBetListProvider betListProvider;
        private readonly ILogService<MatchProvider> logService;

        public MatchProvider(IMatchClient matchClient, IMatchService matchService, IBetListProvider betListProvider, ILogService<MatchProvider> logService)
        {
            if (matchClient == null || matchService == null|| betListProvider==null)
            {
                throw new ArgumentNullException();
            }
            this.matchClient = matchClient;
            this.matchService = matchService;
            this.betListProvider = betListProvider;
            if (logService == null)
            {
                this.logService = new LogService<MatchProvider>();
            }
            else
            {
                this.logService = logService;
            }
        }

        
        /*public bool AddEvent(IReadOnlyList<Event> events)
        {
            return matchClient.AddEvent(events);
        }

        public bool AddMatch(Match match)
        {
            return matchClient.AddMatch(match);
        }

        public bool DeleteEvent(int matchId)
        {
            return matchClient.DeleteEvent(matchId);
        }

        public bool DeleteMatch(int matchId)
        {
            return matchClient.DeleteMatch(matchId);
        }*/

        public IReadOnlyList<Event> GetEventByMatch(int matchId)
        {
            if (matchId <= 0)
            {
                logService.LogError("Class: MatchProvider Method: GetEventByMatch  matchId can not negative");
                throw new ArgumentOutOfRangeException("matchId can not negative");
            }
            return matchService.GetEventsByMatch(matchId);
        }

        public Match GetMatchById(int matchId)
        {
            if (matchId <= 0)
            {
                logService.LogError("Class: MatchProvider Method: GetMatchById  matchId can not negative");
                throw new ArgumentOutOfRangeException("matchId can not negative");
            }
            return matchService.GetMatchById(matchId);
        }

        public IReadOnlyList<Match> GetMatchBySportDateStatus(int sportId, string dateMatch, int status)
        {
            if (status > 3||status<0)
            {
                logService.LogError("Class: MatchProvider Method: GetMatchBySportDateStatus status must be in the interval [0;3]");
                throw new ArgumentOutOfRangeException();
            }
            IReadOnlyList<Sport> sports = betListProvider.GetSports();
            bool flag = false;
            foreach(Sport sport in sports)
            {
                if(sport.SportId==sportId)
                {
                    flag = true;
                    break;
                }
            }
            if(sportId==0)
            {
                flag = true;
            }
            if(!flag)
            {
                logService.LogError("Class: MatchProvider Method: GetMatchBySportDateStatus  sportId must be positive");
                throw new ArgumentException();
            }
            /*if(dateMatch!=string.Empty)
            {
                try
                {
                    DateTime dtParse = DateTime.Parse(dateMatch);
                }
                catch(FormatException ex)
                {
                    throw new FormatException();
                }
            }*/
            //dateMatch = "123";
            return matchService.GetMatchBySportDateStatus(sportId, dateMatch, status);
        }

        public IReadOnlyList<Match> GetMatchesAll()
        {
            return matchService.GetMatchsAll();
        }

        public IReadOnlyList<Result> GetResultsAll()
        {
            return matchService.GetResultsAll();
        }

        /*public bool UpdateEvent(Event[] events)
        {
            return matchClient.UpdateEvent(events);
        }

        public bool UpdateMatch(Match match)
        {
            return matchClient.UpdateMatch(match);
        }*/
    }
}
