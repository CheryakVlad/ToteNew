using System.Collections.Generic;

namespace Data.Clients
{
    public interface IBetListClient
    {
        IReadOnlyList<ToteService.BetListDto> GetBets(int? sportId, int? tournamentId);
        IReadOnlyList<ToteService.BetListDto> GetBetsAll();

        
        
        ToteService.SportDto GetSport(int? id);
        IReadOnlyList<ToteService.SportDto> GetSports();
        IReadOnlyList<ToteService.TournamentDto> GetTournament(int? sportId);
        IReadOnlyList<ToteService.TournamentDto> GetTournamentes();
    }
}
