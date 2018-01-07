using Common.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface IDataService
    {
        IReadOnlyList<Match> GetBets(int? sportId, int? tournamentId);
        IReadOnlyList<Match> GetBetsAll();
        IReadOnlyList<Bet> GetBetByRateId(int rateId, out double total);

        IReadOnlyList<Event> GetEvents();
        IReadOnlyList<Event> GetEvents(int id);
        
        IReadOnlyList<Basket> GetBasketByUser(int userId, out double total);
        Basket GetBasketById(int basketId, int userId);

        IReadOnlyList<Rate> GetRateByUserId(int userId);
        
    }
}
