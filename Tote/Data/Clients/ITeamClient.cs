﻿using Common.Models;
using System.Collections.Generic;

namespace Data.Clients
{
    public interface ITeamClient
    {
        bool UpdateTeam(Team team);

        bool AddTeam(Team team);

        bool DeleteTeam(int teamId);

        IReadOnlyList<TeamService.TeamDto> GetTeamsAll();

        TeamService.TeamDto GetTeamById(int teamId);

        IReadOnlyList<TeamService.CountryDto> GetCountriesAll();

        IReadOnlyList<TeamService.TeamDto> GetTeamsByTournament(int tournamentId);
    }
}
