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
        

        public IReadOnlyList<Event> GetEventByMatch(int matchId)
        {
            if (matchId <= 0)
            {
                logService.LogError("Class: MatchProvider Method: GetEventByMatch  matchId can not negative");
                return null;
            }
            return matchService.GetEventsByMatch(matchId);
        }

        public Match GetMatchById(int matchId)
        {
            if (matchId <= 0)
            {
                logService.LogError("Class: MatchProvider Method: GetMatchById  matchId can not negative");
                return null;
            }
            return matchService.GetMatchById(matchId);
        }

        public IReadOnlyList<Match> GetMatchBySportDateStatus(int sportId, string dateMatch, int status)
        {
            if (status > 3||status<0)
            {
                logService.LogError("Class: MatchProvider Method: GetMatchBySportDateStatus status must be in the interval [0;3]");
                return null;
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
                return null;
            }
            
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
                
    }
}
