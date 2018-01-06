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
        IReadOnlyList<Match> GetBetList(int? sportId, int? tournamentId);
        IReadOnlyList<Match> GetBetAll();

        IReadOnlyList<Match> GetMatchesAll();

        Sport GetSport(int? id);
        IReadOnlyList<Sport> GetSports();        

        IReadOnlyList<Event> GetEvents();
        IReadOnlyList<Event> GetEvents(int id);
                
        IReadOnlyList<Basket> GetBasketByUser(int userId, out double total);
        
        Basket GetBasketById(int basketId, int userId);        

        IReadOnlyList<Rate> GetRateByUserId(int userId);
        IReadOnlyList<Bet> GetBetByRateId(int rateId, out double total);
    }
}
