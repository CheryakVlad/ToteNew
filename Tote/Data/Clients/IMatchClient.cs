using Common.Models;
using System.Collections.Generic;

namespace Data.Clients
{
    public interface IMatchClient
    {
        bool UpdateMatch(Match match);

        bool AddMatch(Match match);

        bool DeleteMatch(int matchId);

        IReadOnlyList<TeamService.MatchDto> GetMatchesAll();

        TeamService.MatchDto GetMatchById(int matchId);

        IReadOnlyList<TeamService.SortDto> GetMatchBySportDateStatus(int sportId, string dateMatch, int status);
        IReadOnlyList<TeamService.ResultDto> GetResultsAll();
    }
}
