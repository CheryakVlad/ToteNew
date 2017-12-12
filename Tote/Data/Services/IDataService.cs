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
        Tournament GetTournamentById(int tournamentId);
        IReadOnlyList<Sport> GetSports();
        IReadOnlyList<Tournament> GetTournament(int? sportId);
        IReadOnlyList<Tournament> GetTournamentes();

        IReadOnlyList<Event> GetEvents();
        IReadOnlyList<Event> GetEvents(int id);
        IReadOnlyList<Team> GetTeamsAll();
        Team GetTeamById(int teamId);
        IReadOnlyList<Country> GetCountriesAll();

        IReadOnlyList<Team> GetTeamsByTournament(int tournamentId);

        IReadOnlyList<Basket> GetBasketByUser(int userId);

        Basket GetBasketById(int basketId, int userId);
    }
}
