using System;
using System.Collections.Generic;
using Common.Models;
using Data.Clients;
using Common.Logger;

namespace Business.Service
{
    public class UpdateMatchService : IUpdateMatchService
    {
        private readonly IMatchClient matchClient;
        private readonly ILogService<UpdateMatchService> logService;
        public UpdateMatchService(IMatchClient matchClient, ILogService<UpdateMatchService> logService)
        {
            if (matchClient == null)
            {
                throw new ArgumentNullException();
            }
            this.matchClient = matchClient;
            if (logService == null)
            {
                this.logService = new LogService<UpdateMatchService>();
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
                logService.LogError("Class: UpdateMatchService Method: AddEvent  Events don't add to DB");
                throw new NullReferenceException("Events is null");
            }
            return matchClient.AddEvent(events);
        }

        public bool AddMatch(Match match)
        {
            if (match == null)
            {
                logService.LogError("Class: UpdateMatchService Method: AddMatch  Match don't add to DB");
                throw new NullReferenceException("Match is null");
            }
            return matchClient.AddMatch(match);
        }

        public bool DeleteEvent(int matchId)
        {
            if (matchId <= 0)
            {
                logService.LogError("Class: UpdateMatchService Method: DeleteEvent  Event don't delete from DB");
                throw new ArgumentOutOfRangeException("matchId <= 0");
            }
            return matchClient.DeleteEvent(matchId);
        }

        public bool DeleteMatch(int matchId)
        {
            if (matchId <= 0)
            {
                logService.LogError("Class: UpdateMatchService Method: DeleteMatch  Match don't delete from DB");
                throw new ArgumentOutOfRangeException("matchId <= 0");
            }
            return matchClient.DeleteMatch(matchId);
        }

        public bool UpdateEvent(Event[] events)
        {
            if (events == null)
            {
                logService.LogError("Class: UpdateMatchService Method: UpdateEvent  Events don't update from DB");
                throw new ArgumentOutOfRangeException("events == null");
            }
            return matchClient.UpdateEvent(events);
        }

        public bool UpdateMatch(Match match)
        {
            if (match == null)
            {
                logService.LogError("Class: UpdateMatchService Method: UpdateMatch  Match don't update from DB");
                throw new ArgumentOutOfRangeException("match == null");
            }
            return matchClient.UpdateMatch(match);
        }
    }
}
