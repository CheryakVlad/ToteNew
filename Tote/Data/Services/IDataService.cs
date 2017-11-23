using Common.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface IDataService
    {
        IList<RateList> GetRates(int? sportId, int? tournamentId);
        IList<RateList> GetRatesAll();


        Sport GetSport(int? id);
        IList<Sport> GetSports();
        IList<Tournament> GetTournament(int? sportId);
        IList<Tournament> GetTournamentes();

    }
}
