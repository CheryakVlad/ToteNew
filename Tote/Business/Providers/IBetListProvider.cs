using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Providers
{
    public interface IBetListProvider
    {
        IReadOnlyList<Bet> GetBetList(int? sportId, int? tournamentId);
        IReadOnlyList<Bet> GetBetAll();

        Sport GetSport(int? id);
        IReadOnlyList<Sport> GetSports();
        IReadOnlyList<Tournament> GetTournament(int? sportId);
        IReadOnlyList<Tournament> GetTournamentes();
    }
}
