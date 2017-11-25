using System.Collections.Generic;
using System.Linq;
using Service.Contracts.Dto;
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Service.Contracts.Contracts
{
    public class Parameter
    {
        public DbType Type { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
    }

    public class Connection<T> where T:class
    {
        public SqlCommand GetCommand(SqlConnection connection, SqlCommand command, CommandType type, string commandText, List<Parameter> parameters = null)
        {
            command.Connection = connection;
            command.CommandType = type;
            command.CommandText = commandText;
            connection.Open();
            if (parameters!=null)
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
            if (t==typeof(BetListDto))
            {
                var BetListDto = new BetListDto()
                {
                    BetId = (int)reader[0],
                    WinCommandHome = (int)reader[1],
                    WinCommandGuest = (int)reader[2],
                    Draw = (int)reader[3],
                    CommandHome = reader[4].ToString(),
                    CommandGuest = reader[5].ToString()
                    //Date=(DateTime)reader[6]
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

    public class RateListService : IRateListService
    {
        
        public List<BetListDto> GetBets(int? sportId, int? tournamentId)
        {
            var betsListDto = new List<BetListDto>();

            if (sportId == 0)
            {
                betsListDto= GetBetsAll();
            }
            else
            {
                if (tournamentId == 0)
                {
                    betsListDto = GetBetsBySport((int)sportId);
                }
                else
                {
                    betsListDto = GetBetsBySportTournament((int)sportId,(int)tournamentId);
                }
            }


            return betsListDto;
        }
        
        public List<BetListDto> GetBetsAll()
        {
            var betListDto = new List<BetListDto>();

            Connection<BetListDto> connection = new Connection<BetListDto>();

            betListDto = connection.GetConnection(CommandType.StoredProcedure, "GetBetsAll");
            
            return betListDto;
        }
        

        public List<BetListDto> GetBetsBySport(int sportId)
        {
            var betListDto = new List<BetListDto>();

            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportId });

            Connection<BetListDto> connection = new Connection<BetListDto>();

            betListDto = connection.GetConnection(CommandType.StoredProcedure, "GetBetsBySport", parameters);

            return betListDto;
        }

        public List<BetListDto> GetBetsBySportTournament(int sportId, int tournamentId)
        {
            var betListDto = new List<BetListDto>();

            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = tournamentId });

            Connection<BetListDto> connection = new Connection<BetListDto>();

            betListDto = connection.GetConnection(CommandType.StoredProcedure, "GetBetsBySportTournament", parameters);

            return betListDto;
        }

        public SportDto GetSport(int? id)
        {

            var sportDto = new SportDto();

            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = id });
            

            Connection<SportDto> connection = new Connection<SportDto>();

            sportDto = connection.GetConnection(CommandType.StoredProcedure, "GetSportById", parameters)[0];

            return sportDto;
            
        }

        public List<SportDto> GetSports()
        {
            var sportDto = new List<SportDto>();

            
            Connection<SportDto> connection = new Connection<SportDto>();

            sportDto = connection.GetConnection(CommandType.StoredProcedure, "GetSportsAll");

            return sportDto;           
        }

        public List<TournamentDto> GetTournament(int? sportId)
        {
            var tornamentDtos = new List<TournamentDto>();

            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportId });


            Connection<TournamentDto> connection = new Connection<TournamentDto>();

            tornamentDtos = connection.GetConnection(CommandType.StoredProcedure, "GetTournamentsBySportId", parameters);

            return tornamentDtos;
            
        }

        public List<TournamentDto> GetTournamentes()
        {
            var tornamentDtos = new List<TournamentDto>(); 

            Connection<TournamentDto> connection = new Connection<TournamentDto>();

            tornamentDtos = connection.GetConnection(CommandType.StoredProcedure, "GetTournamentsAll");

            return tornamentDtos;
            
        }
        
    }
}
