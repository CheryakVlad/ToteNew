using Service.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Service.Contracts.Common
{
    public class Connection<T> where T : class
    {
        public SqlCommand GetCommand(SqlConnection connection, SqlCommand command, CommandType type, string commandText, IReadOnlyList<Parameter> parameters = null)
        {
            command.Connection = connection;
            command.CommandType = type;
            command.CommandText = commandText;
            try
            {
                connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    var param = new SqlParameter();
                    param.DbType = parameter.Type;
                    param.ParameterName = parameter.Name;
                    param.Value = parameter.Value;
                    command.Parameters.Add(param);
                }
            }


            return command;
        }

        public bool GetConnectionUpdate(CommandType type, string commandText, IReadOnlyList<Parameter> parameters = null)
        {
            var ListDto = new List<T>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultDb"].ConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    var number = GetCommand(connection, command, type, commandText, parameters).ExecuteNonQuery();   
                    if(number>0)
                    {
                        return true;
                    }                 
                    connection.Close();
                }
            }
            return false;
        }

        public int GetConnectionAddRate(CommandType type, string commandText, IReadOnlyList<Parameter> parameters = null)
        {
            var ListDto = new List<T>();
            var rateId = 1;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultDb"].ConnectionString))
            {
                using (var command = new SqlCommand())
                {                    
                    var reader = GetCommand(connection, command, type, commandText, parameters).ExecuteReader();                    
                    while (reader.Read())
                    {
                        rateId = (int)reader[0];                        
                    }
                    connection.Close();
                }
            }
            return rateId;
        }

        public T [] GetConnection(CommandType type, string commandText, IReadOnlyList<Parameter> parameters = null)
        {
            var ListDto = new List<T>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultDb"].ConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    var reader = GetCommand(connection, command, type, commandText, parameters).ExecuteReader();
                    
                    while (reader.Read())
                    {
                        var obj = CreateListDto(reader);
                        if (obj is T)
                        {
                            ListDto.Add((T)obj);
                        }
                    }
                    connection.Close();
                }
            }
            return ListDto.ToArray();
        }
        public object CreateListDto(SqlDataReader reader)
        {
            Type t = typeof(T);
            if (t == typeof(BasketDto))
            {
                var BasketDto = new BasketDto()
                {
                    BasketId=(int)reader[0],
                    UserId=(int)reader[1],
                    MatchId=(int)reader[2],
                    EventId=(int)reader[3]
                };
                return BasketDto;
            }

            if (t == typeof(TeamDto))
            {
                var TeamDto = new TeamDto()
                {
                    TeamId=(int)reader[0],
                    Name=reader[1].ToString(),
                    SportId=(int)reader[2],
                    Sport=reader[3].ToString(),
                    CountryId=(int)reader[4],
                    Country=reader[5].ToString()
                };
                return TeamDto;
            }

            if (t == typeof(RateDto))
            {
                var RateDto = new RateDto()
                {
                    RateId=(int)reader[0],
                    DateRate= reader.GetDateTime(1),
                    Amount= reader.GetDecimal(2),
                    UserId=(int) reader[3], 
                    Status=reader.GetBoolean(4)
                };
                return RateDto;
            }

            if (t == typeof(BetDto))
            {                
                var BetDto = new BetDto()
                {
                    BetId = (int)reader[0],
                    MatchId = (int)reader[1],
                    Status = reader.GetBoolean(2),                    
                    EventId = (int)reader[3]                    
                };
                return BetDto;
            }

            if (t== typeof(EventDto))
            {
                var EventDto = new EventDto()
                {
                    EventId=(int)reader[0],
                    Name=reader[1].ToString(),
                    Coefficient=(double)reader[2],
                    MatchId=(int)reader[3]
                };
                return EventDto;
            }

            if (t == typeof(RoleDto))
            {
                var RoleDto = new RoleDto()
                {
                    RoleId=(int)reader[0],
                    Name=reader[1].ToString()
                };
                return RoleDto;
            }

            if (t == typeof(CountryDto))
            {
                var CountryDto = new CountryDto()
                {
                    CountryId=(int)reader[0],                    
                    Name=reader[1].ToString()
                };
                return CountryDto;
            }

            if (t == typeof(ResultDto))
            {
                var ResultDto = new ResultDto()
                {
                    ResultId = (int)reader[0],
                    Name = reader[1].ToString()
                };
                return ResultDto;
            }

            if (t == typeof(SortDto))
            {
                var SortDto = new SortDto()
                {
                    MatchId=(int)reader[0],
                    TeamHome=reader[1].ToString(),
                    TeamGuest=reader[2].ToString(),
                    DateMatch=reader.GetDateTime(3),
                    TeamHomeCountry= reader[4].ToString(),
                    TeamGuestCountry= reader[5].ToString(),
                    Score= reader[7].ToString(),
                    Tournament=reader[8].ToString()
                };
                return SortDto;
            }

            if (t == typeof(UserDto))
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
                    Role = reader[9].ToString()                    
                };
                return UserDto;
            }
            if (t == typeof(MatchDto))
            {
                var MatchDto = new MatchDto()
                {
                    MatchId = (int)reader[0],
                    TeamIdHome=(int)reader[1],
                    TeamHome=reader[2].ToString(),
                    TeamIdGuest=(int)reader[3],
                    TeamGuest=reader[4].ToString(),
                    Date= reader.GetDateTime(5),
                    CountryHomeId=(int)reader[6],
                    CountryHome=reader[7].ToString(),
                    CountryGuestId=(int)reader[8],
                    CountryGuest=reader[9].ToString(),
                    TournamentId=(int)reader[10],
                    Tournament=reader[11].ToString(),
                    Score=reader[12].ToString(),
                    ResultId=(int)reader[13],
                    Result=reader[14].ToString(),
                    SportId=(int)reader[15]
                };

                return MatchDto;
            }

            if (t == typeof(BetListDto))
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
            else
            {
                if (t == typeof(SportDto))
                {
                    var SportDto = new SportDto()
                    {
                        SportId = (int)reader[0],
                        Name = reader[1].ToString()
                    };

                    return SportDto;
                }
                else
                {
                    var TournamentDto = new TournamentDto()
                    {
                        TournamentId = (int)reader[0],
                        Name = reader[1].ToString(),
                        SportId = (int)reader[2],
                        Sport=reader[3].ToString()
                    };
                    return TournamentDto;
                }
            }
        }

    }
}
