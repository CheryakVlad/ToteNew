using System.Collections.Generic;
using Service.Contracts.Dto;
using System.Data;
using Service.Contracts.Common;
using System.Data.SqlClient;
using System.ServiceModel;
using Service.Contracts.Exception;

namespace Service.Contracts.Contracts
{

    public class BetListService : IBetListService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BetListService));

        public IList<BetListDto> GetBets(int? sportId, int? tournamentId)
        {          
            if (sportId == 0)
            {
                return GetBetsAll();
            }
            else
            {
                if (tournamentId == 0)
                {
                    return GetBetsBySport((int)sportId);
                }
                else
                {
                    return GetBetsBySportTournament((int)sportId,(int)tournamentId);
                }
            }            
        }

        

        public IList<BetListDto> GetBetsAll()
        {            
            try
            {
                var connection = new Connection<BetListDto>();               
                return connection.GetConnection(CommandType.StoredProcedure, "GetBetsAll"); ;
            }
            catch(SqlException sqlEx)
            {
                CustomException exception = new CustomException();
                exception.Title = "GetBetsAll";
                throw new FaultException<CustomException>(exception, sqlEx.Message);
                log.Error(sqlEx.Message);
            }
        }
        

        public IList<BetListDto> GetBetsBySport(int sportId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportId });

            var connection = new Connection<BetListDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetBetsBySport", parameters); ;
            }
            catch (SqlException sqlEx)
            {
                CustomException exception = new CustomException();
                exception.Title = "GetBetsBySport";
                throw new FaultException<CustomException>(exception, sqlEx.Message);
                log.Error(sqlEx.Message);
            }
        }

        public IList<BetListDto> GetBetsBySportTournament(int sportId, int tournamentId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = tournamentId });

            var connection = new Connection<BetListDto>();
            try
            {
               return connection.GetConnection(CommandType.StoredProcedure, "GetBetsBySportTournament", parameters); 
            }
            catch (SqlException sqlEx)
            {
                CustomException exception = new CustomException();
                exception.Title = "GetBetsBySportTournament";
                throw new FaultException<CustomException>(exception, sqlEx.Message);
                log.Error(sqlEx.Message);
            }
        }

        public SportDto GetSport(int? id)
        {

            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = id });


            var connection = new Connection<SportDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetSportById", parameters)[0];
            }
            catch (SqlException sqlEx)
            {
                CustomException exception = new CustomException();
                exception.Title = "GetSportById";
                throw new FaultException<CustomException>(exception, sqlEx.Message);
                log.Error(sqlEx.Message);
            }
            
        }

        public IList<SportDto> GetSports()
        {            
            var connection = new Connection<SportDto>();
            try
            {
                 return connection.GetConnection(CommandType.StoredProcedure, "GetSportsAll");
            }
            catch (SqlException sqlEx)
            {
                CustomException exception = new CustomException();
                exception.Title = "GetSportsAll";
                throw new FaultException<CustomException>(exception, sqlEx.Message);
                log.Error(sqlEx.Message);
            }
        }

        public IList<TournamentDto> GetTournament(int? sportId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportId });


            var connection = new Connection<TournamentDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetTournamentsBySportId", parameters);
            }
            catch (SqlException sqlEx)
            {
                CustomException exception = new CustomException();
                exception.Title = "GetTournamentsBySportId";
                throw new FaultException<CustomException>(exception, sqlEx.Message);
                log.Error(sqlEx.Message);
            }
            
        }

        public IList<TournamentDto> GetTournamentes()
        {
            var connection = new Connection<TournamentDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetTournamentsAll");
            }
            catch (SqlException sqlEx)
            {
                CustomException exception = new CustomException();
                exception.Title = "GetTournamentsAll";
                throw new FaultException<CustomException>(exception, sqlEx.Message);
                log.Error(sqlEx.Message);
            }
            
        }
        
    }
}
