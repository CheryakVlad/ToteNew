using Service.Contracts.Dto;
using System.Data.SqlClient;

namespace Service.Contracts.Common
{
    internal class CreateDto
    {
        public BasketDto CreateBasketDto(SqlDataReader reader)
        {
            var BasketDto = new BasketDto()
            {
                BasketId = (int)reader[0],
                UserId = (int)reader[1],
                MatchId = (int)reader[2],
                EventId = (int)reader[3]
            };
            return BasketDto;
        }
        public TeamDto CreateTeamDto(SqlDataReader reader)
        {
            var TeamDto = new TeamDto()
            {
                TeamId = (int)reader[0],
                Name = reader[1].ToString(),
                SportId = (int)reader[2],
                Sport = reader[3].ToString(),
                CountryId = (int)reader[4],
                Country = reader[5].ToString()
            };
            return TeamDto;
        }
        public RateDto CreateRateDto(SqlDataReader reader)
        {
            var RateDto = new RateDto()
            {
                RateId = (int)reader[0],
                DateRate = reader.GetDateTime(1),
                Amount = reader.GetDecimal(2),
                UserId = (int)reader[3],
                Status = reader.GetBoolean(4)
            };
            return RateDto;
        }
        public BetDto CreateBetDto(SqlDataReader reader)
        {
            var BetDto = new BetDto()
            {
                BetId = (int)reader[0],
                MatchId = (int)reader[1],
                Status = reader.GetBoolean(2),
                EventId = (int)reader[3],
                Sport = reader[4].ToString(),
                Tournament = reader[5].ToString()
            };
            return BetDto;
        }
        public EventDto CreateEventDto(SqlDataReader reader)
        {
            var EventDto = new EventDto()
            {
                EventId = (int)reader[0],
                Name = reader[1].ToString(),
                Coefficient = (double)reader[2],
                MatchId = (int)reader[3]
            };
            return EventDto;
        }
        public RoleDto CreateRoleDto(SqlDataReader reader)
        {
            var RoleDto = new RoleDto()
            {
                RoleId = (int)reader[0],
                Name = reader[1].ToString()
            };
            return RoleDto;
        }
        public CountryDto CreateCountryDto(SqlDataReader reader)
        {
            var CountryDto = new CountryDto()
            {
                CountryId = (int)reader[0],
                Name = reader[1].ToString()
            };
            return CountryDto;
        }
        public ResultDto CreateResultDto(SqlDataReader reader)
        {
            var ResultDto = new ResultDto()
            {
                ResultId = (int)reader[0],
                Name = reader[1].ToString()
            };
            return ResultDto;
        }
        public SortDto CreateSortDto(SqlDataReader reader)
        {
            var SortDto = new SortDto()
            {
                MatchId = (int)reader[0],
                TeamHome = reader[1].ToString(),
                TeamGuest = reader[2].ToString(),
                DateMatch = reader.GetDateTime(3),
                TeamHomeCountry = reader[4].ToString(),
                TeamGuestCountry = reader[5].ToString(),
                Score = reader[7].ToString(),
                Tournament = reader[8].ToString()
            };
            return SortDto;
        }
        public UserDto CreateUserDto(SqlDataReader reader)
        {
            var UserDto = new UserDto()
            {
                UserId = (int)reader[0],
                Login = reader[1].ToString(),
                Password = reader[2].ToString(),
                Email = reader[3].ToString(),
                Money = reader.GetDecimal(5),
                FIO = reader[6].ToString(),
                PhoneNumber = reader[7].ToString(),
                Role = reader[9].ToString(),
                RoleId = (int)reader[10]
            };
            return UserDto;
        }
        public MatchDto CreateMatchDto(SqlDataReader reader)
        {
            var MatchDto = new MatchDto()
            {
                MatchId = (int)reader[0],
                TeamIdHome = (int)reader[1],
                TeamHome = reader[2].ToString(),
                TeamIdGuest = (int)reader[3],
                TeamGuest = reader[4].ToString(),
                Date = reader.GetDateTime(5),
                CountryHomeId = (int)reader[6],
                CountryHome = reader[7].ToString(),
                CountryGuestId = (int)reader[8],
                CountryGuest = reader[9].ToString(),
                TournamentId = (int)reader[10],
                Tournament = reader[11].ToString(),
                Score = reader[12].ToString(),
                ResultId = (int)reader[13],
                Result = reader[14].ToString(),
                SportId = (int)reader[15]               
            };
            return MatchDto;
        }
        public BetListDto CreateBetListDto(SqlDataReader reader)
        {
            var BetListDto = new BetListDto()
            {
                MatchId = (int)reader[0],
                CommandHome = reader[1].ToString(),
                CommandGuest = reader[2].ToString(),
                Date = reader.GetDateTime(3),
                CountryHome = reader.GetString(4),
                CountryGuest = reader.GetString(5)
            };
            return BetListDto;
        }
        public SportDto CreateSportDto(SqlDataReader reader)
        {
            var SportDto = new SportDto()
            {
                SportId = (int)reader[0],
                Name = reader[1].ToString()
            };
            return SportDto;
        }
        public TournamentDto CreateTournamentDto(SqlDataReader reader)
        {
            var TournamentDto = new TournamentDto()
            {
                TournamentId = (int)reader[0],
                Name = reader[1].ToString(),
                SportId = (int)reader[2],
                Sport = reader[3].ToString()
            };
            return TournamentDto;
        }
    }
}
