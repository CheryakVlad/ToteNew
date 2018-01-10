using Common.Models;
using System.Collections.Generic;

namespace Business.Providers
{
    public interface IBetListProvider
    {
        IReadOnlyList<Match> GetBetList(int? sportId, int? tournamentId);
        IReadOnlyList<Match> GetBetAll();
        IReadOnlyList<Bet> GetBetByRateId(int rateId, out double total);
        IReadOnlyList<Bet> GetBetByMatchId(int matchId);

        IReadOnlyList<Event> GetEvents();
        IReadOnlyList<Event> GetEvents(int id);
                
        IReadOnlyList<Basket> GetBasketByUser(int userId, out double total);        
        Basket GetBasketById(int basketId, int userId);        

        IReadOnlyList<Rate> GetRateByUserId(int userId);
        
    }
}
