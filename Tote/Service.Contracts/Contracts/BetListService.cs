using System.Collections.Generic;
using Service.Contracts.Dto;
using System.Data;
using Service.Contracts.Common;
using System.Data.SqlClient;
using System.ServiceModel;
using Service.Contracts.Exception;
using System;

namespace Service.Contracts.Contracts
{

    public class BetListService : IBetListService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BetListService));

        public BetListDto[] GetBets(int? sportId, int? tournamentId)
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

        

        public BetListDto[] GetBetsAll()
        {
            var connection = new Connection<BetListDto>();
             
            try
            {                 
                connection.GetConnection(CommandType.StoredProcedure, "GetBetsAll");
                
                return connection.GetConnection(CommandType.StoredProcedure, "GetBetsAll");
            }
            catch(SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetBetsAll";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);                
            }
        }
        

        public BetListDto[] GetBetsBySport(int sportId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportId });

            var connection = new Connection<BetListDto>();
            
            try
            {       
                return connection.GetConnection(CommandType.StoredProcedure, "GetBetsBySport", parameters); 
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetBetsBySport";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
                
            }
        }

        public BetListDto[] GetBetsBySportTournament(int sportId, int tournamentId)
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
                var exception = new CustomException();
                exception.Title = "GetBetsBySportTournament";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
                
            }
        }

        public EventDto[] GetEvents(int? id)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@MatchId", Value = id });

            var connection = new Connection<EventDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetCoefficientByMatch", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetCoefficientByMatch";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public EventDto[] GetEventsAll()
        {
            var connection = new Connection<EventDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetCoefficients");
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "[GetCoefficients]";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
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
                var exception = new CustomException();
                exception.Title = "GetSportById";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);                
            }
            
        }

        public SportDto[] GetSports()
        {            
            var connection = new Connection<SportDto>();
            try
            {
                 return connection.GetConnection(CommandType.StoredProcedure, "GetSportsAll");
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetSportsAll";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);                
            }
        }

        public TournamentDto[] GetTournament(int? sportId)
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
                var exception = new CustomException();
                exception.Title = "GetTournamentsBySportId";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);                
            }
            
        }

        public TournamentDto[] GetTournamentes()
        {
            var connection = new Connection<TournamentDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetTournamentsAll");
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetTournamentsAll";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);                
            }
            
        }

       
    }
}
