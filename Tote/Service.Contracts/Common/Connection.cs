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
        public SqlCommand GetCommand(SqlConnection connection, SqlCommand command, CommandType type, string commandText, List<Parameter> parameters = null)
        {
            command.Connection = connection;
            command.CommandType = type;
            command.CommandText = commandText;
            try
            {
                connection.Open();
            }
            catch (SqlException ex)
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

        public List<T> GetConnection(CommandType type, string commandText, List<Parameter> parameters = null)
        {
            var ListDto = new List<T>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultDb"].ConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    var reader = GetCommand(connection, command, type, commandText, parameters).ExecuteReader();

                    while (reader.Read())
                    {
                        object obj = CreateListDto(reader);
                        if (obj is T)
                        {
                            ListDto.Add((T)obj);
                        }
                    }
                    connection.Close();
                }
            }
            return ListDto;
        }
        public object CreateListDto(SqlDataReader reader)
        {
            Type t = typeof(T);
            if (t == typeof(BetListDto))
            {
                var BetListDto = new BetListDto()
                {
                    BetId = (int)reader[0],
                    WinCommandHome = reader.GetDouble(1),
                    WinCommandGuest = reader.GetDouble(2),
                    Draw = reader.GetDouble(3),
                    CommandHome = reader[4].ToString(),
                    CommandGuest = reader[5].ToString(),
                    Date = reader.GetDateTime(6),
                    CountryHome = reader.GetString(7),
                    CountryGuest = reader.GetString(8)
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
