
using Common.Models;
using System.Collections.Generic;

namespace Data.Services
{
    public interface ITeamService
    {
        IReadOnlyList<Team> GetTeamsAll();
        Team GetTeamById(int teamId);
        IReadOnlyList<Team> GetTeamsByTournament(int tournamentId);

        IReadOnlyList<Country> GetCountriesAll();
        Country GetCountryById(int countryId);
    }
}
