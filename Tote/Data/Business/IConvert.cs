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
    }
}
