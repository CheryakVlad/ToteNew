using System.Collections.Generic;
using Common.Models;
namespace Data.Business
{
    public interface IConvert
    {
        IList<RateList> ToRatesList(IList<ToteService.RateListDto> ratesListDto);
        IList<Sport> ToSport(IList<ToteService.SportDto> sportsDto);
        IList<Tournament> ToTournament(IList<ToteService.TournamentDto> tournamentsDto);
        Sport ToSport(ToteService.SportDto sportDto);
    }
}
