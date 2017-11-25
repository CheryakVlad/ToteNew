using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Providers
{
    public interface IRateListProvider
    {
        IList<Bet> GetRateList(int? sportId, int? tournamentId);
        IList<Bet> GetRateAll();

        Sport GetSport(int? id);
        IList<Sport> GetSports();
        IList<Tournament> GetTournament(int? sportId);
        IList<Tournament> GetTournamentes();
    }
}
