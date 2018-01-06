using Common.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface IDataService
    {
        IReadOnlyList<Match> GetBets(int? sportId, int? tournamentId);
        IReadOnlyList<Match> GetBetsAll();

        IReadOnlyList<Match> GetMatchesAll();

        Sport GetSport(int? id);
        
        IReadOnlyList<Sport> GetSports();       

        IReadOnlyList<Event> GetEvents();
        IReadOnlyList<Event> GetEvents(int id);
        IReadOnlyList<Team> GetTeamsAll();
        Team GetTeamById(int teamId);
        IReadOnlyList<Country> GetCountriesAll();
        Country GetCountryById(int countryId);

        IReadOnlyList<Team> GetTeamsByTournament(int tournamentId);

        IReadOnlyList<Basket> GetBasketByUser(int userId, out double total);

        Basket GetBasketById(int basketId, int userId);

        IReadOnlyList<Rate> GetRateByUserId(int userId);
        IReadOnlyList<Bet> GetBetByRateId(int rateId, out double total);
    }
}
