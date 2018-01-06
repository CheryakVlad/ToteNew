using Common.Models;
using System.Collections.Generic;

namespace Business.Providers
{
    public interface ITournamentProvider
    {
        Tournament GetTournamentById(int tournamentId);
        IReadOnlyList<Tournament> GetTournament(int? sportId);
        IReadOnlyList<Tournament> GetTournamentes();
        IReadOnlyList<Tournament> GetTournamentesByTeamId(int teamId);
    }
}
