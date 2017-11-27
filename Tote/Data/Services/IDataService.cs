using Common.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface IDataService
    {
        IList<Bet> GetBets(int? sportId, int? tournamentId);
        IList<Bet> GetBetsAll();


        Sport GetSport(int? id);
        IList<Sport> GetSports();
        IList<Tournament> GetTournament(int? sportId);
        IList<Tournament> GetTournamentes();

    }
}
