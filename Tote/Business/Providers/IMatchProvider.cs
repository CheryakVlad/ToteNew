using Common.Models;
using System.Collections.Generic;

namespace Business.Providers
{
    public interface IMatchProvider
    {
        Match GetMatchById(int matchId);
        IReadOnlyList<Match> GetMatchesAll();        

        IReadOnlyList<Match> GetMatchBySportDateStatus(int sportId, string dateMatch, int status);
        Match GetMatchWithEvents(int matchId);
        IReadOnlyList<Result> GetResultsAll();

        IReadOnlyList<Event> GetEventByMatch(int matchId);

        
    }
}
