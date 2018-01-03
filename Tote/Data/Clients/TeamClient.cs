using System;
using System.Collections.Generic;
using Common.Models;
using Data.TeamService;
using Data.Business;
using System.ServiceModel;
using Common.Logger;

namespace Data.Clients
{
    public class TeamClient : ITeamClient
    {        
        private readonly IConvert convert;
        private readonly ILogService<TeamClient> logService;

        public TeamClient(IConvert convert):this(convert,new LogService<TeamClient>())
        {

        }

        public TeamClient(IConvert convert, ILogService<TeamClient> logService)
        {
            if (convert == null)
            {
                throw new ArgumentNullException();
            }
            this.convert = convert;
            if (logService == null)
            {
                this.logService = new LogService<TeamClient>();
            }
            else
            {
                this.logService = logService;
            }
        }
        
        public bool AddCountry(Country country)
        {
            if (country == null)
            {
                logService.LogError("Class: TeamClient Method: AddCountry country is null");
                return false;
            }
            var countryDto = new CountryDto();
            countryDto = convert.ToCountryDto(country);
            var model = new bool();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.AddCountry(countryDto);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool AddTeam(Team team)
        {
            if (team == null)
            {
                logService.LogError("Class: TeamClient Method: AddTeam team is null");
                return false;
            }
            var teamDto = new TeamDto();
            teamDto = convert.ToTeamDto(team);
            var model = new bool();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.AddTeam(teamDto);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool AddTournamentForTeam(int tournamentId, int teamId)
        {
            if (tournamentId <= 0|| teamId <= 0)
            {
                logService.LogError("Class: TeamClient Method: AddTournamentForTeam tournamentId or teamId is not positive");
                return false;
            }
            var model = new bool();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.AddTournamentForTeam(tournamentId, teamId);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool DeleteCountry(int countryId)
        {
            if (countryId <= 0)
            {
                logService.LogError("Class: TeamClient Method: DeleteCountry countryId is not positive");
                return false;
            }
            var model = new bool();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.DeleteCountry(countryId);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool DeleteTeam(int teamId)
        {
            if (teamId <= 0)
            {
                logService.LogError("Class: TeamClient Method: DeleteTeam teamId is not positive");
                return false;
            }
            var model = new bool();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.DeleteTeam(teamId);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool DeleteTournamentForTeam(int tournamentId, int teamId)
        {
            if (teamId <= 0 || tournamentId <= 0)
            {
                logService.LogError("Class: TeamClient Method: DeleteTournamentForTeam teamId or tournamentId is not positive");
                return false;
            }
            var model = new bool();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.DeleteTournamentForTeam(tournamentId, teamId);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public IReadOnlyList<CountryDto> GetCountriesAll()
        {
            var model = new List<CountryDto>();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    var countries=client.GetCountriesAll();
                    foreach (var country in countries)
                    {
                        model.Add(country);
                    }
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }

                }
                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }

            }

            return model;
        }

        public CountryDto GetCountryById(int countryId)
        {
            if (countryId <= 0 )
            {
                logService.LogError("Class: TeamClient Method: GetCountryById countryId is not positive");
                return null;
            }
            var model = new CountryDto();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.GetCountryById(countryId);
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }
            }
            return model;
        }

        public TeamDto GetTeamById(int teamId)
        {
            if (teamId <= 0)
            {
                logService.LogError("Class: TeamClient Method: GetTeamById teamId is not positive");
                return null;
            }
            var model = new TeamDto();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.GetTeamById(teamId);
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }

            }
            return model;
        }

        public IReadOnlyList<TeamDto> GetTeamsAll()
        {
            var model = new List<TeamDto>();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    var teams = client.GetTeams();
                    foreach (var team in teams)
                    {
                        model.Add(team);
                    }
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }

                }
                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }
            }

            return model;
        }

        public IReadOnlyList<TeamDto> GetTeamsByTournament(int tournamentId)
        {
            if (tournamentId < 0)
            {
                logService.LogError("Class: TeamClient Method: GetTeamsByTournament tournamentId is negative");
                return null;
            }
            var model = new List<TeamDto>();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    var teams = client.GetTeamsByTournament(tournamentId);
                    foreach (var team in teams)
                    {
                        model.Add(team);
                    }
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }

                }
                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }
            }

            return model;
        }

        public bool UpdateCountry(Country country)
        {
            if (country == null)
            {
                logService.LogError("Class: TeamClient Method: UpdateCountry country is null");
                return false;
            }
            var countryDto = new CountryDto();
            countryDto = convert.ToCountryDto(country);
            var model = new bool();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.UpdateCountry(countryDto);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool UpdateTeam(Team team)
        {
            if (team == null)
            {
                logService.LogError("Class: TeamClient Method: UpdateTeam team is null");
                return false;
            }
            var teamDto = new TeamDto();
            teamDto = convert.ToTeamDto(team);
            var model = new bool();
            using (var client = new TeamService.TeamServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.UpdateTeam(teamDto);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }

            }
            return model;
        }
    }
}
