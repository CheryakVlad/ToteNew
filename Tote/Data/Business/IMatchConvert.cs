using Common.Models;
using System.Collections.Generic;

namespace Data.Business
{
    public interface IMatchConvert
    {
        TeamService.MatchDto ToMatchDto(Match match);
        Match ToMatch(TeamService.MatchDto matchDto);
        IReadOnlyList<Match> ToMatches(IReadOnlyList<TeamService.MatchDto> matchesDto);
        IReadOnlyList<Match> ToMatches(IReadOnlyList<TeamService.SortDto> sortesDto);
        IReadOnlyList<Result> ToResult(IReadOnlyList<TeamService.ResultDto> resultsDto);

        IReadOnlyList<Event> ToEvent(IReadOnlyList<TeamService.EventDto> eventsDto);
        TeamService.EventDto[] ToEventDto(IReadOnlyList<Event> events);

        IReadOnlyList<Match> ToMatchList(IReadOnlyList<ToteService.BetListDto> betsListDto);

    }
}
