using Common.Models;

namespace Business.Service
{
    public interface IUpdateBetListService
    {
        bool AddBasket(int matchId, int eventId, int userId);
        bool DeleteBasket(int basketId);
        void AddBets(decimal amount, int userId);
        bool AddBet(Bet bet, int basketId);
        int AddRate(decimal amount, int userId);
    }
}
