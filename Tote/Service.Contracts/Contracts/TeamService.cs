using System;
using System.Collections.Generic;
using System.Linq;
using Service.Contracts.Dto;
using Service.Contracts.Common;
using System.Data;
using System.Data.SqlClient;
using Service.Contracts.Exception;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    public class TeamService : ITeamService,IMatchService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TeamService));

        public bool AddMatch(MatchDto matchDto)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.DateTime, Name = "@DateMatch", Value = matchDto.Date });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@ResultId", Value = matchDto.ResultId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = matchDto.TournamentId });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Score", Value = matchDto.Score });
            var connection = new Connection<TeamDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "AddMatch", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "AddMatch";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public bool AddTeam(TeamDto teamDto)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Name", Value = teamDto.Name });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@CountryId", Value = teamDto.CountryId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = teamDto.SportId });
            var connection = new Connection<TeamDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "AddTeam", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "AddTeam";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public bool DeleteMatch(int matchId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TeamId", Value = matchId });

            var connection = new Connection<MatchDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "DeleteMatch", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "DeleteMatch";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool DeleteTeam(int teamId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@MatchId", Value = teamId });

            var connection = new Connection<TeamDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "DeleteTeam", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "DeleteTeam";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        

        public MatchDto GetMatchById(int matchId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@MatchId", Value = matchId });

            var connection = new Connection<MatchDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetMatchById", parameters)[0];
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetMatchById";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public MatchDto[] GetMatchesAll()
        {
            var connection = new Connection<MatchDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetMatchesAll");
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetMatchesAll";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public TeamDto[] GetTeam(int? teamId)
        {
            throw new NotImplementedException();
        }

        public TeamDto GetTeamById(int teamId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TeamId", Value = teamId });

            var connection = new Connection<TeamDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetTeamById", parameters)[0];
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetTeamById";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public TeamDto[] GetTeams()
        {
            var connection = new Connection<TeamDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetTeamsAll");
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetTeamsAll";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public bool UpdateMatch(MatchDto matchDto)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@MatchId", Value = matchDto.MatchId });
            parameters.Add(new Parameter { Type = DbType.DateTime, Name = "@DateMatch", Value = matchDto.Date });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@ResultId", Value = matchDto.ResultId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = matchDto.TournamentId });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Score", Value = matchDto.Score });

            var connection = new Connection<MatchDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "UpdateMatch", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "UpdateMatch";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool UpdateTeam(TeamDto teamDto)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TeamId", Value = teamDto.TeamId });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Name", Value = teamDto.Name });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@CountryId", Value = teamDto.CountryId });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@SportId", Value = teamDto.SportId });

            var connection = new Connection<TeamDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "UpdateTeam", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "UpdateTeam";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }
    }
}
