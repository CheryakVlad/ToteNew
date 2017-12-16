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

        public MatchProvider(IMatchClient matchClient, IMatchService matchService)
        {
            this.matchClient = matchClient;
            this.matchService = matchService;
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
