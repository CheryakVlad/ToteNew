using Common.Models;
using System.Collections.Generic;

namespace Data.Business
{
    public interface IMatchConvert
    {
        TeamService.MatchDto ToMatchDto(Match match);
        Match ToMatch(TeamService.MatchDto matchDto);
        IReadOnlyList<Match> ToMatches(IReadOnlyList<TeamService.MatchDto> matchesDto);
    }
}
