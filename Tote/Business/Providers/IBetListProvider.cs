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
        IReadOnlyList<Tournament> GetTournament(int? sportId);
        IReadOnlyList<Tournament> GetTournamentes();

        IReadOnlyList<Event> GetEvents();
        IReadOnlyList<Event> GetEvents(int id);

        bool UpdateSport(Sport sport);

        bool AddSport(Sport sport);

        bool DeleteSport(int sportId);

        bool AddBasket(Basket basket);
        bool DeleteBasket(int basketId);
        IReadOnlyList<Basket> GetBasketByUser(int userId, out double total);

        IReadOnlyList<Match> GetMatchesByBasket(int userId);
        Basket GetBasketById(int basketId, int userId);

        bool AddBet(Bet bet, int basketId);
        int AddRate(Rate rate);
    }
}
