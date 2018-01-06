using Common.Models;
using System.Collections.Generic;

namespace Data.Clients
{
    public interface ITournamentClient
    {
        bool UpdateTournament(Tournament tournament);
        bool AddTournament(Tournament tournament);
        bool DeleteTournament(int tournamentId);
        ToteService.TournamentDto GetTournamentById(int tournamentId);
        IReadOnlyList<ToteService.TournamentDto> GetTournament(int? sportId);
        IReadOnlyList<ToteService.TournamentDto> GetTournamentesByTeamId(int teamId);
        IReadOnlyList<ToteService.TournamentDto> GetTournamentes();
    }
}
