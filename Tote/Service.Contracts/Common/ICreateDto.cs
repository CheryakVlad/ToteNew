
using Service.Contracts.Dto;
using System.Data.SqlClient;

namespace Service.Contracts.Common
{
    public interface ICreateDto
    {
        BasketDto CreateBasketDto(SqlDataReader reader);
        TeamDto CreateTeamDto(SqlDataReader reader);
        RateDto CreateRateDto(SqlDataReader reader);
        BetDto CreateBetDto(SqlDataReader reader);
        EventDto CreateEventDto(SqlDataReader reader);
        RoleDto CreateRoleDto(SqlDataReader reader);
        CountryDto CreateCountryDto(SqlDataReader reader);
        ResultDto CreateResultDto(SqlDataReader reader);
        SortDto CreateSortDto(SqlDataReader reader);
        UserDto CreateUserDto(SqlDataReader reader);
        MatchDto CreateMatchDto(SqlDataReader reader);
        BetListDto CreateBetListDto(SqlDataReader reader);
        SportDto CreateSportDto(SqlDataReader reader);
        TournamentDto CreateTournamentDto(SqlDataReader reader);
        
    }
}
