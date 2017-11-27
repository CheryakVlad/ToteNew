using System.Collections.Generic;

namespace Data.Clients
{
    public interface IBetListClient
    {
        IList<ToteService.BetListDto> GetBets(int? sportId, int? tournamentId);
        IList<ToteService.BetListDto> GetBetsAll();

        
        
        ToteService.SportDto GetSport(int? id);
        IList<ToteService.SportDto> GetSports();
        IList<ToteService.TournamentDto> GetTournament(int? sportId);
        IList<ToteService.TournamentDto> GetTournamentes();
    }
}
