using Common.Models;

namespace Business.Providers
{
    public interface ITournamentProvider
    {
        /*bool UpdateTournament(Tournament tournament);

        bool AddTournament(Tournament tournament);

        bool DeleteTournament(int tournamentId);*/

        Tournament GetTournamentById(int tournamentId);
    }
}
