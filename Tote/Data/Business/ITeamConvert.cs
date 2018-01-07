using Common.Models;
using Data.TeamService;
using System.Collections.Generic;

namespace Data.Business
{
    public interface ITeamConvert
    {
        Team ToTeam(TeamDto teamDto);
        TeamDto ToTeamDto(Team team);
        IReadOnlyList<Team> ToTeams(IReadOnlyList<TeamDto> teamsDto);

        IReadOnlyList<Country> ToCountry(IReadOnlyList<TeamService.CountryDto> countriesDto);
        Country ToCountry(TeamService.CountryDto countryDto);
        TeamService.CountryDto ToCountryDto(Country country);
    }
}
