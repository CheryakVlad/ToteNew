using Service.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Service.Contracts.Common
{
    public class Connection<T> : IConnection<T> where T : class
    {
        private readonly ICreateDto createDto;
        private IDictionary<object, Func<SqlDataReader, object>> dtoDictionary;

        public Connection():this(new CreateDto())
        {

        }           

        public Connection(ICreateDto createDto)
        {
            if(createDto == null)
            {
                throw new ArgumentNullException();
            }
            this.createDto = createDto;
            dtoDictionary = new Dictionary<object, Func<SqlDataReader, object>>()
            {
                {typeof(TournamentDto), createDto.CreateTournamentDto},
                {typeof(SportDto), createDto.CreateSportDto},
                {typeof(BetListDto), createDto.CreateBetListDto},
                {typeof(BasketDto), createDto.CreateBasketDto},
                {typeof(TeamDto), createDto.CreateTeamDto},
                {typeof(RateDto), createDto.CreateRateDto},
                {typeof(BetDto), createDto.CreateBetDto},
                {typeof(EventDto), createDto.CreateEventDto},
                {typeof(RoleDto), createDto.CreateRoleDto},
                {typeof(CountryDto), createDto.CreateCountryDto},
                {typeof(ResultDto), createDto.CreateResultDto},
                {typeof(SortDto), createDto.CreateSortDto},
                {typeof(UserDto), createDto.CreateUserDto},
                {typeof(MatchDto), createDto.CreateMatchDto}
            };
        }
        public object CreateListDto(SqlDataReader reader)
        {
            if (!dtoDictionary.ContainsKey(typeof(T)))
            {
                throw new ArgumentException();
            }
            return dtoDictionary[typeof(T)](reader);
        }


        public SqlCommand GetCommand(SqlConnection connection, SqlCommand command, CommandType type, string commandText, IReadOnlyList<Parameter> parameters = null)
        {
            command.Connection = connection;
            command.CommandType = type;
            command.CommandText = commandText;            

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
                    connection.Open();
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
                    connection.Open();
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
                    connection.Open();
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

        public void DefineDto(object obj, Func<SqlDataReader, object> body)
        {      
            if (dtoDictionary.ContainsKey(typeof(T)))
            {
                throw new ArgumentException();
            }
            dtoDictionary.Add(obj, body);
        }

                
        
    }

}

