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
        public bool AddMatch(Match match)
        {
            return matchClient.AddMatch(match);
        }

        public bool DeleteMatch(int matchId)
        {
            return matchClient.DeleteMatch(matchId);
        }

        public Match GetMatchById(int matchId)
        {
            return matchService.GetMatchById(matchId);
        }

        public IReadOnlyList<Match> GetMatchBySportDateStatus(int sportId, string dateMatch, int status)
        {
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

        public bool UpdateMatch(Match match)
        {
            return matchClient.UpdateMatch(match);
        }
    }
}
