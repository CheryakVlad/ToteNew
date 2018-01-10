using Common.Models;
using System.Collections.Generic;

namespace Data.Clients
{
    public interface IBetListClient
    {
        IReadOnlyList<ToteService.BetListDto> GetBets(int? sportId, int? tournamentId);
        IReadOnlyList<ToteService.BetListDto> GetBetsAll();
        bool AddBet(Bet bet, int basketId);
        IReadOnlyList<ToteService.BetDto> GetBetByRateId(int rateId);

        IReadOnlyList<ToteService.EventDto> GetEvents();
        IReadOnlyList<ToteService.EventDto> GetEvents(int id);

        IReadOnlyList<ToteService.BasketDto> GetBasketByUser(int userId);
        bool AddBasket(Basket basket);
        bool DeleteBasket(int basketId);
        ToteService.BasketDto GetBasketById(int basketId, int userId);
        
        int AddRate(Rate rate);
        IReadOnlyList<ToteService.RateDto> GetRateByUserId(int userId);
        IReadOnlyList<ToteService.BetDto> GetBetByMatchId(int matchId);


    }
}
