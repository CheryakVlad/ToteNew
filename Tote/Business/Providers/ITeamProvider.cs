using Common.Models;
using System.Collections.Generic;

namespace Business.Providers
{
    public interface ITeamProvider
    {
        Team GetTeamById(int teamId);
        IReadOnlyList<Team> GetTeamsAll();        
        
        /*bool UpdateTeam(Team team);

        bool AddTeam(Team team);

        bool DeleteTeam(int teamId);

        bool AddTournamentForTeam(int tournamentId, int teamId);

        bool DeleteTournamentForTeam(int tournamentId, int teamId);*/

        IReadOnlyList<Country> GetCountriesAll();

        IReadOnlyList<Team> GetTeamsByTournament(int tournamentId);

        /*bool UpdateCountry(Country country);

        bool AddCountry(Country country);

        bool DeleteCountry(int countryId);*/

        Country GetCountryById(int countryId);
    }
}
