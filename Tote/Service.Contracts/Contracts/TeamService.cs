using System;
using System.Collections.Generic;
using Service.Contracts.Dto;
using Service.Contracts.Common;
using System.Data;
using System.Data.SqlClient;
using Service.Contracts.Exception;
using System.ServiceModel;
using Service.Contracts.Logger;


namespace Service.Contracts.Contracts
{
    public class TeamService : ITeamService,IMatchService,IEventService
    {
        private readonly ILogService<TeamService> logService;
        private IConnection<SortDto> connectionSortDto;
        //private IDictionary<object, Func<CommandType, string, List<Parameter>, object>> dtoDictionary;

        public TeamService():this(new LogService<TeamService>(), new Connection<SortDto>())
        {
            
        }

        public TeamService(ILogService<TeamService> logService, IConnection<SortDto> connectionSortDto)
        {
            if(connectionSortDto == null)
            {
                throw new ArgumentNullException();
            }
            this.connectionSortDto = connectionSortDto;
                      
            if (logService == null)
            {
                this.logService = new LogService<TeamService>();
            }
            else
            {
                this.logService = logService;
            }

        }

        private void GenerateFaultException(string title, string exceptionMessage)
        {
            var exception = new CustomException();
            exception.Title = title;
            logService.LogError(exception.Title);
            throw new FaultException<CustomException>(exception, exceptionMessage);
        }

        public bool AddCountry(CountryDto countryDto)
        {
            if (countryDto == null||countryDto.Name==String.Empty)
            {
                GenerateFaultException("AddCountry", "ArgumentException");
            }
            var parameters = new List<Parameter>();            
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Name", Value = countryDto.Name });
            var connection = new Connection<CountryDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "AddCountry", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "AddCountry";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public bool AddEvents(IReadOnlyList<EventDto> eventDto)
        {
            if (eventDto == null || eventDto.Count <3)
            {
                GenerateFaultException("AddEventMatch", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@MatchId", Value = eventDto[0].MatchId });
            parameters.Add(new Parameter { Type = DbType.Double, Name = "@Win", Value = eventDto[0].Coefficient });
            parameters.Add(new Parameter { Type = DbType.Double, Name = "@Loss", Value = eventDto[1].Coefficient });
            parameters.Add(new Parameter { Type = DbType.Double, Name = "@Draw", Value = eventDto[2].Coefficient });
            var connection = new Connection<EventDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "AddEventMatch", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "AddEventMatch";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public bool AddMatch(MatchDto matchDto)
        {
            if (matchDto == null)
            {
                GenerateFaultException("AddMatch", "ArgumentException");
            }
            if (matchDto.ResultId==0)
            {
                matchDto.ResultId = 3;
            }
            if (matchDto.Score == null)
            {
                matchDto.Score = "0";
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.DateTime, Name = "@DateMatch", Value = matchDto.Date });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@ResultId", Value = matchDto.ResultId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = matchDto.TournamentId });            
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Score", Value = matchDto.Score });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TeamHomeId", Value = matchDto.TeamIdHome });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TeamGuestId", Value = matchDto.TeamIdGuest });
            var connection = new Connection<TeamDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "AddMatch", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "AddMatch";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public bool AddTeam(TeamDto teamDto)
        {
            if (teamDto == null||string.IsNullOrEmpty(teamDto.Name))
            {
                GenerateFaultException("AddTeam", "ArgumentException");
            }
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
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public bool DeleteCountry(int countryId)
        {
            if (countryId <= 0)
            {
                GenerateFaultException("DeleteCountry", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@CountryId", Value = countryId });

            var connection = new Connection<CountryDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "DeleteCountry", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "DeleteCountry";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool DeleteEvents(int matchId)
        {
            if (matchId <= 0)
            {
                GenerateFaultException("DeleteEventMatch", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@MatchId", Value = matchId });

            var connection = new Connection<EventDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "DeleteEventMatch", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "DeleteEventMatch";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool DeleteMatch(int matchId)
        {
            if (matchId <= 0)
            {
                GenerateFaultException("DeleteMatch", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@MatchId", Value = matchId });

            var connection = new Connection<MatchDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "DeleteMatch", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "DeleteMatch";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool DeleteTeam(int teamId)
        {
            if (teamId <= 0)
            {
                GenerateFaultException("DeleteTeam", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TeamId", Value = teamId });

            var connection = new Connection<TeamDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "DeleteTeam", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "DeleteTeam";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public CountryDto[] GetCountriesAll()
        {            
            var connection = new Connection<CountryDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetCountriesAll");                
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetCountriesAll";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public CountryDto GetCountryById(int countryId)
        {
            if (countryId <= 0)
            {
                GenerateFaultException("GetCountryById", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@CountryId", Value = countryId });

            var connection = new Connection<CountryDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetCountryById", parameters)[0];
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetCountryById";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public CountryDto GetCountryByTeam(int teamId)
        {
            if (teamId <= 0)
            {
                GenerateFaultException("GetCountryByTeam", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TeamId", Value = teamId });

            var connection = new Connection<CountryDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetCountryByTeam", parameters)[0];
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetCountryByTeam";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public EventDto[] GetEvents(int id)
        {
            if (id <= 0)
            {
                GenerateFaultException("GetCoefficientByMatch", "ArgumentException");
            }
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
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }
       

        public MatchDto GetMatchById(int matchId)
        {
            if (matchId <= 0)
            {
                GenerateFaultException("GetMatchById", "ArgumentException");
            }
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
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public SortDto[] GetMatchBySportDateStatus(int sportId, string dateMatch, int status)
        {
            if (sportId < 0 || status < 0 || status>3)
            {
                GenerateFaultException("GetMatchesBySportDateStatusSP", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportId });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@DateMatch", Value = dateMatch });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@Status", Value = status });

            //var connection = new Connection<SortDto>();
            try
            {
                //return connection.GetConnection(CommandType.StoredProcedure, "GetMatchesBySportDateStatusSP", parameters);
                return connectionSortDto.GetConnection(CommandType.StoredProcedure, "GetMatchesBySportDateStatusSP", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetMatchesBySportDateStatusSP";
                logService.LogError(sqlEx.Message);
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
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public ResultDto[] GetResultsAll()
        {
            var connection = new Connection<ResultDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetResultsAll");
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetResultsAll";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }               

        public TeamDto GetTeamById(int teamId)
        {
            if (teamId <= 0)
            {
                GenerateFaultException("GetMatchesBySportDateStatusSP", "ArgumentException");
            }
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
                logService.LogError(sqlEx.Message);
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
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public TeamDto[] GetTeamsByTournament(int tournamentId)
        {
            if (tournamentId < 0)
            {
                GenerateFaultException("GetTeamByTournament", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = tournamentId });
           

            var connection = new Connection<TeamDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetTeamByTournament", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetTeamByTournament";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public bool UpdateCountry(CountryDto countryDto)
        {
            if (countryDto == null)
            {
                GenerateFaultException("UpdateCountry", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@CountryId", Value = countryDto.CountryId });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Name", Value = countryDto.Name });
            
            var connection = new Connection<CountryDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "UpdateCountry", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "UpdateCountry";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool UpdateEvents(EventDto[] eventDto)
        {
            if (eventDto == null || eventDto.Length < 3)
            {
                GenerateFaultException("UpdateCountry", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@MatchId", Value = eventDto[0].MatchId });
            parameters.Add(new Parameter { Type = DbType.Double, Name = "@Win", Value = eventDto[0].Coefficient });
            parameters.Add(new Parameter { Type = DbType.Double, Name = "@Loss", Value = eventDto[1].Coefficient });
            parameters.Add(new Parameter { Type = DbType.Double, Name = "@Draw", Value = eventDto[2].Coefficient });

            var connection = new Connection<EventDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "UpdateEventMatch", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "UpdateEventMatch";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool UpdateMatch(MatchDto matchDto)
        {
            if (matchDto == null)
            {
                GenerateFaultException("UpdateMatch", "ArgumentException");
            }
            if (matchDto.Score == null)
            {
                matchDto.Score = "0";
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@MatchId", Value = matchDto.MatchId });
            parameters.Add(new Parameter { Type = DbType.DateTime, Name = "@DateMatch", Value = matchDto.Date });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@ResultId", Value = matchDto.ResultId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = matchDto.TournamentId });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Score", Value = matchDto.Score });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TeamHomeId", Value = matchDto.TeamIdHome });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TeamGuestId", Value = matchDto.TeamIdGuest });

            var connection = new Connection<MatchDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "UpdateMatch", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "UpdateMatch";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool UpdateTeam(TeamDto teamDto)
        {
            if (teamDto == null)
            {
                GenerateFaultException("UpdateTeam", "ArgumentException");
            }
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
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool AddTournamentForTeam(int tournamentId, int teamId)
        {
            if (tournamentId <= 0 || teamId <= 0)
            {
                GenerateFaultException("AddTeamTournament", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TeamId", Value = teamId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = tournamentId });
            var connection = new Connection<TeamDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "AddTeamTournament", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "AddTeamTournament";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }

        public bool DeleteTournamentForTeam(int tournamentId, int teamId)
        {
            if (tournamentId <= 0 || teamId <= 0)
            {
                GenerateFaultException("DeleteTeamTournament", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TeamId", Value = teamId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = tournamentId });
            var connection = new Connection<TeamDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "DeleteTeamTournament", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "DeleteTeamTournament";
                logService.LogError(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }
    }
}
