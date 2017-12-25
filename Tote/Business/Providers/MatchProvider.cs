using System;
using System.Collections.Generic;
using Common.Models;
using Data.Services;
using Data.Clients;

namespace Business.Providers
{
    public class MatchProvider : IMatchProvider
    {
        private readonly IMatchClient matchClient;
        private readonly IMatchService matchService;
        private readonly IBetListProvider betListProvider;

        public MatchProvider(IMatchClient matchClient, IMatchService matchService, IBetListProvider betListProvider)
        {
            this.matchClient = matchClient;
            this.matchService = matchService;
            this.betListProvider = betListProvider;
        }

        public static MatchProvider createMatchProvider(IMatchClient matchClient, IMatchService matchService, IBetListProvider betListProvider)
        {
            if (matchClient == null || matchService == null|| betListProvider==null)
            {
                throw new ArgumentNullException();
            }
            return new MatchProvider(matchClient, matchService, betListProvider);
        }

        public bool AddEvent(IReadOnlyList<Event> events)
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
        }

        public IReadOnlyList<Event> GetEventByMatch(int matchId)
        {
            return matchService.GetEventsByMatch(matchId);
        }

        public Match GetMatchById(int matchId)
        {
            return matchService.GetMatchById(matchId);
        }

        public IReadOnlyList<Match> GetMatchBySportDateStatus(int sportId, string dateMatch, int status)
        {
            if (status > 3||status<0)
            {
                throw new ArgumentException();
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

        public bool UpdateEvent(Event[] events)
        {
            return matchClient.UpdateEvent(events);
        }

        public bool UpdateMatch(Match match)
        {
            return matchClient.UpdateMatch(match);
        }
    }
}
