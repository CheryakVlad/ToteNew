using Common.Models;
using System.Collections.Generic;

namespace Data.Clients
{
    public interface IBetListClient
    {
        IReadOnlyList<ToteService.BetListDto> GetBets(int? sportId, int? tournamentId);
        IReadOnlyList<ToteService.BetListDto> GetBetsAll();        

        ToteService.SportDto GetSport(int? id);
        IReadOnlyList<ToteService.SportDto> GetSports();
        bool UpdateSport(Sport sport);
        bool AddSport(Sport sport);
        bool DeleteSport(int sportId);

        IReadOnlyList<ToteService.TournamentDto> GetTournament(int? sportId);
        IReadOnlyList<ToteService.TournamentDto> GetTournamentes();

        IReadOnlyList<ToteService.EventDto> GetEvents();
        IReadOnlyList<ToteService.EventDto> GetEvents(int id);

        IReadOnlyList<ToteService.BasketDto> GetBasketByUser(int userId);
        bool AddBasket(Basket basket);
        bool DeleteBasket(int basketId);

        ToteService.BasketDto GetBasketById(int basketId, int userId);
    }
}
