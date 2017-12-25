using System;
using System.Collections.Generic;
using Common.Models;
using Data.TeamService;
using Data.Business;
using System.ServiceModel;

namespace Data.Clients
{
    public class TeamClient : ITeamClient
    {
        private readonly log4net.ILog log;
        private readonly IConvert convert;

        public TeamClient(IConvert convert)
        {
            this.convert = convert;
            this.log = log4net.LogManager.GetLogger(typeof(TeamClient));
        }

        public static TeamClient createTeamClient(IConvert convert)
        {
            if (convert == null)
            {
                throw new ArgumentNullException();
            }
            return new TeamClient(convert);
        }

        public bool AddCountry(Country country)
        {
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
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool AddTeam(Team team)
        {
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
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool AddTournamentForTeam(int tournamentId, int teamId)
        {                 
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
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool DeleteCountry(int countryId)
        {
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
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool DeleteTeam(int teamId)
        {
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
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool DeleteTournamentForTeam(int tournamentId, int teamId)
        {
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
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }

            }

            return model;
        }

        public CountryDto GetCountryById(int countryId)
        {
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }
            }
            return model;
        }

        public TeamDto GetTeamById(int teamId)
        {
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }
            }

            return model;
        }

        public IReadOnlyList<TeamDto> GetTeamsByTournament(int tournamentId)
        {
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
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    log.Error(nullEx.Message);
                    return null;
                }
            }

            return model;
        }

        public bool UpdateCountry(Country country)
        {
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
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool UpdateTeam(Team team)
        {
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
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }
    }
}
