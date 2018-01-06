

using Common.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface ITournamentService
    {
        IReadOnlyList<Tournament> GetTournament(int? sportId);
        Tournament GetTournamentById(int tournamentId);
        IReadOnlyList<Tournament> GetTournamentes();
        IReadOnlyList<Tournament> GetTournamentesByTeamId(int teamId);
       
    }
}
