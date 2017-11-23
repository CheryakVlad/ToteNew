using System.Collections.Generic;

namespace Data.Clients
{
    public interface IRateListClient
    {
        IList<ToteService.RateListDto> GetRates(int? sportId, int? tournamentId);
        IList<ToteService.RateListDto> GetRatesAll();

        
        
        ToteService.SportDto GetSport(int? id);
        IList<ToteService.SportDto> GetSports();
        IList<ToteService.TournamentDto> GetTournament(int? sportId);
        IList<ToteService.TournamentDto> GetTournamentes();
    }
}
