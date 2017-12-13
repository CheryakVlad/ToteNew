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

    public class BetListService : IBetListService,ITournamentService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BetListService));

        public bool AddSport(SportDto sportDto)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Name", Value = sportDto.Name });  
            var connection = new Connection<SportDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "AddSport", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "AddSport";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool AddTournament(TournamentDto tournamentDto)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Name", Value = tournamentDto.Name });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = tournamentDto.SportId });

            var connection = new Connection<TournamentDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "AddTournament", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "AddTournament";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public bool DeleteSport(int sportId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportId });

            var connection = new Connection<SportDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "DeleteSport", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "DeleteSport";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool DeleteTournament(int tournamentId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = tournamentId });

            var connection = new Connection<TournamentDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "DeleteTournament", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "DeleteTournament";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

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

        public TournamentDto GetTournamentById(int tournamentId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = tournamentId });

            var connection = new Connection<TournamentDto>();

            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetTournamentById", parameters)[0];
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetTournamentById";
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

        public bool UpdateSport(SportDto sportDto)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportDto.SportId });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Name", Value = sportDto.Name });
            

            var connection = new Connection<SportDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "UpdateSport", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "UpdateSport";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool UpdateTournament(TournamentDto tournamentDto)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = tournamentDto.TournamentId });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Name", Value = tournamentDto.Name });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = tournamentDto.SportId });

            var connection = new Connection<TournamentDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "UpdateTournament", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "UpdateTournament";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public TournamentDto[] GetTournamentesBySport(int sportId)
        {
            throw new NotImplementedException();
        }

        public bool AddBasket(BasketDto basketDto)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.String, Name = "@UserId", Value = basketDto.UserId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@MatchId", Value = basketDto.MatchId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@EventId", Value = basketDto.EventId });
            var connection = new Connection<BasketDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "AddBasket", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "AddBasket";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool DeleteBasket(int basketId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@BasketId", Value = basketId });

            var connection = new Connection<BasketDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "DeleteBasket", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "DeleteBasket";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public BasketDto[] GetBasketByUser(int userId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@UserId", Value = userId });

            var connection = new Connection<BasketDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetBasketByUser", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetBasketByUser";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public BasketDto GetBasketById(int basketId, int userId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@BasketId", Value = basketId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@UserId", Value = userId });

            var connection = new Connection<BasketDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetBasketById", parameters)[0];
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetBasketById";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public int GetRateIdAfterAdd(RateDto rateDto)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.DateTime, Name = "@DateRate", Value = rateDto.DateRate });
            parameters.Add(new Parameter { Type = DbType.Decimal, Name = "@RateAmount", Value = rateDto.Amount });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@UserId", Value = rateDto.UserId });

            var connection = new Connection<RateDto>();
            try
            {
                return connection.GetConnectionAddRate(CommandType.StoredProcedure, "AddRate", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "AddRate";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public bool AddBet(BetDto betDto, int basketId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@RateId", Value = betDto.RateId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@MatchId", Value = betDto.MatchId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@EventId", Value = betDto.EventId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@BasketId", Value = basketId });
            var connection = new Connection<BasketDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "AddBet", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "AddBet";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }
    }
}
