﻿using System;
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
            logService.LogError("Class: MatchService Method: GetUserById user is null");
            return new Match();
        }

        public IReadOnlyList<Match> GetMatchsAll()
        {
            var dto = matchClient.GetMatchesAll();

            if (dto != null)
            {
                return convert.ToMatches(dto);
            }
            return new List<Match>();
        }

        public IReadOnlyList<Match> GetMatchBySportDateStatus(int sportId, string dateMatch, int status)
        {
            var dto = matchClient.GetMatchBySportDateStatus(sportId, dateMatch, status);

            if (dto != null)
            {
                return convert.ToMatches(dto);
            }
            return new List<Match>();
        }

        public IReadOnlyList<Result> GetResultsAll()
        {
            var dto = matchClient.GetResultsAll();

            if (dto != null)
            {
                return convert.ToResult(dto);
            }
            return new List<Result>();
        }

        public IReadOnlyList<Event> GetEventsByMatch(int matchId)
        {
            var dto = matchClient.GetEventByMatch(matchId);

            if (dto != null)
            {
                return convert.ToEvent(dto);
            }
            return new List<Event>();
        }
    }
}
