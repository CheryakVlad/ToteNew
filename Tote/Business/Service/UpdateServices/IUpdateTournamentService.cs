using Common.Models;

namespace Business.Service
{
    public interface IUpdateTournamentService
    {
        bool UpdateTournament(Tournament tournament);

        bool AddTournament(Tournament tournament);

        bool DeleteTournament(int tournamentId);
    }
}
