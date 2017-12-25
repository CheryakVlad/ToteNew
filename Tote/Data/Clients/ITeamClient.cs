using Common.Models;
using System.Collections.Generic;

namespace Data.Clients
{
    public interface ITeamClient
    {
        bool UpdateTeam(Team team);

        bool AddTeam(Team team);

        bool DeleteTeam(int teamId);

        bool AddTournamentForTeam(int tournamentId, int teamId);

        bool DeleteTournamentForTeam(int tournamentId, int teamId);

        bool UpdateCountry(Country country);

        bool AddCountry(Country country);

        bool DeleteCountry(int countryId);

        IReadOnlyList<TeamService.TeamDto> GetTeamsAll();

        TeamService.TeamDto GetTeamById(int teamId);

        IReadOnlyList<TeamService.CountryDto> GetCountriesAll();

        TeamService.CountryDto GetCountryById(int countryId);

        IReadOnlyList<TeamService.TeamDto> GetTeamsByTournament(int tournamentId);
    }
}
