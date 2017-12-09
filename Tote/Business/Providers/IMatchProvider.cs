using Common.Models;
using System.Collections.Generic;

namespace Business.Providers
{
    public interface IMatchProvider
    {
        Match GetMatchById(int matchId);
        IReadOnlyList<Match> GetMatchesAll();

        bool UpdateMatch(Match match);

        bool AddMatch(Match match);

        bool DeleteMatch(int matchId);

        IReadOnlyList<Match> GetMatchBySportDateStatus(int sportId, string dateMatch, int status);
        IReadOnlyList<Result> GetResultsAll();
    }
}
