using System.Collections.Generic;
using Common.Models;
namespace Data.Business
{
    public interface IConvert
    {
        IList<Bet> ToBetsList(IList<ToteService.BetListDto> betsListDto);
        IList<Sport> ToSport(IList<ToteService.SportDto> sportsDto);
        IList<Tournament> ToTournament(IList<ToteService.TournamentDto> tournamentsDto);
        Sport ToSport(ToteService.SportDto sportDto);
    }
}
