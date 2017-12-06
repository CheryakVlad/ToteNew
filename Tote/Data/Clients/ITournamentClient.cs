using Common.Models;

namespace Data.Clients
{
    public interface ITournamentClient
    {
        bool UpdateTournament(Tournament tournament);

        bool AddTournament(Tournament tournament);

        bool DeleteTournament(int tournamentId);

        ToteService.TournamentDto GetTournamentById(int tournamentId);
    }
}
