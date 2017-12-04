using System.Collections.Generic;

namespace Data.Clients
{
    public interface IBetListClient
    {
        IReadOnlyList<ToteService.BetListDto> GetBets(int? sportId, int? tournamentId);
        IReadOnlyList<ToteService.BetListDto> GetBetsAll();

        //IReadOnlyList<ToteService.BetListDto> GetMatch(int id);

        ToteService.SportDto GetSport(int? id);
        IReadOnlyList<ToteService.SportDto> GetSports();
        IReadOnlyList<ToteService.TournamentDto> GetTournament(int? sportId);
        IReadOnlyList<ToteService.TournamentDto> GetTournamentes();

        IReadOnlyList<ToteService.EventDto> GetEvents();
        IReadOnlyList<ToteService.EventDto> GetEvents(int id);
    }
}
