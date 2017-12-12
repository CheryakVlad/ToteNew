using Common.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface IMatchService
    {
        IReadOnlyList<Match> GetMatchsAll();
        Match GetMatchById(int matchId);
        IReadOnlyList<Match> GetMatchBySportDateStatus(int sportId, string dateMatch, int status);

        IReadOnlyList<Result> GetResultsAll();

        IReadOnlyList<Event> GetEventsByMatch(int matchId);

    }
}
