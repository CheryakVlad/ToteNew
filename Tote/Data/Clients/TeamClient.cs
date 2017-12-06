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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TeamClient));
        private readonly IConvert convert;

        public TeamClient(IConvert convert)
        {
            this.convert = convert;
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
