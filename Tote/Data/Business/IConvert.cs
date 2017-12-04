using System.Collections.Generic;
using Common.Models;
namespace Data.Business
{
    public interface IConvert
    {
        IReadOnlyList<Bet> ToBetsList(IReadOnlyList<ToteService.BetListDto> betsListDto);
        IReadOnlyList<Sport> ToSport(IReadOnlyList<ToteService.SportDto> sportsDto);
        IReadOnlyList<Tournament> ToTournament(IReadOnlyList<ToteService.TournamentDto> tournamentsDto);
        Sport ToSport(ToteService.SportDto sportDto);

        IReadOnlyList<Event> ToEvents(IReadOnlyList<ToteService.EventDto> eventsDto);

        IReadOnlyList<Match> ToMatchList(IReadOnlyList<ToteService.BetListDto> betsListDto);

        IReadOnlyList<Match> ToMatchList(IReadOnlyList<ToteService.BetListDto> betsListDto,IReadOnlyList<ToteService.EventDto> eventsDto );
    }
}
