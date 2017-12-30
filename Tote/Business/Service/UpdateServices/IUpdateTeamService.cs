using Common.Models;

namespace Business.Service
{
    public interface IUpdateTeamService
    {
        bool UpdateTeam(Team team);

        bool AddTeam(Team team);

        bool DeleteTeam(int teamId);

        bool AddTournamentForTeam(int tournamentId, int teamId);

        bool DeleteTournamentForTeam(int tournamentId, int teamId);

        bool UpdateCountry(Country country);

        bool AddCountry(Country country);

        bool DeleteCountry(int countryId);
    }
}
