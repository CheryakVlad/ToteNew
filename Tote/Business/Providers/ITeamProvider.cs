using Common.Models;
using System.Collections.Generic;

namespace Business.Providers
{
    public interface ITeamProvider
    {
        Team GetTeamById(int teamId);
        IReadOnlyList<Team> GetTeamsAll();        
               
        IReadOnlyList<Country> GetCountriesAll();

        IReadOnlyList<Team> GetTeamsByTournament(int tournamentId);
       
        Country GetCountryById(int countryId);
    }
}
