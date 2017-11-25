using Common.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface IDataService
    {
        IList<Bet> GetRates(int? sportId, int? tournamentId);
        IList<Bet> GetRatesAll();


        Sport GetSport(int? id);
        IList<Sport> GetSports();
        IList<Tournament> GetTournament(int? sportId);
        IList<Tournament> GetTournamentes();

    }
}
