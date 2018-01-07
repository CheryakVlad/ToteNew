
using Common.Models;
using Data.TeamService;
using System.Collections.Generic;

namespace Data.Business
{
    public class TeamConvert:ITeamConvert
    {
        public Team ToTeam(TeamDto teamDto)
        {
            if (teamDto == null)
            {
                return null;
            }
            var sport = new Sport
            {
                SportId = teamDto.SportId,
                Name = teamDto.Sport
            };
            var country = new Country
            {
                CountryId = teamDto.CountryId,
                Name = teamDto.Country
            };

            var team = new Team
            {
                TeamId = teamDto.TeamId,
                Name = teamDto.Name,
                SportId = teamDto.SportId,
                Sport = sport,
                CountryId = teamDto.CountryId,
                Country = country
            };

            return team;
        }

        public TeamDto ToTeamDto(Team team)
        {
            if (team == null)
            {
                return null;
            }
            var teamDto = new TeamDto
            {
                TeamId = team.TeamId,
                Name = team.Name,
                SportId = team.SportId,
                CountryId = team.CountryId,
            };

            return teamDto;
        }

        public IReadOnlyList<Team> ToTeams(IReadOnlyList<TeamDto> teamsDto)
        {
            if (teamsDto.Count == 0)
            {
                return null;
            }
            var teamsList = new List<Team>();
            foreach (var teamDto in teamsDto)
            {
                teamsList.Add(ToTeam(teamDto));
            }
            return teamsList;
        }

        public Country ToCountry(CountryDto countryDto)
        {
            if (countryDto == null)
            {
                return null;
            }
            var country = new Country
            {
                CountryId = countryDto.CountryId,
                Name = countryDto.Name
            };
            return country;
        }

        public IReadOnlyList<Country> ToCountry(IReadOnlyList<CountryDto> countriesDto)
        {
            if (countriesDto.Count == 0)
            {
                return null;
            }
            var countriesList = new List<Country>();
            foreach (var countryDto in countriesDto)
            {
                countriesList.Add(ToCountry(countryDto));
            }
            return countriesList;
        }

        public CountryDto ToCountryDto(Country country)
        {
            if (country == null)
            {
                return null;
            }
            var countryDto = new CountryDto
            {
                CountryId = country.CountryId,
                Name = country.Name
            };
            return countryDto;
        }

    }
}
