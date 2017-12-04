using Service.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(t== typeof(EventDto))
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
                    Role= reader[7].ToString()
                };
                return UserDto;
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
                        SportId = (int)reader[2]
                    };
                    return TournamentDto;
                }
            }
        }

    }
}
