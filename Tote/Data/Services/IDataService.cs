using Common.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface IDataService
    {
        IReadOnlyList<Bet> GetBets(int? sportId, int? tournamentId);
        IReadOnlyList<Bet> GetBetsAll();


        Sport GetSport(int? id);
        IReadOnlyList<Sport> GetSports();
        IReadOnlyList<Tournament> GetTournament(int? sportId);
        IReadOnlyList<Tournament> GetTournamentes();

    }
}
