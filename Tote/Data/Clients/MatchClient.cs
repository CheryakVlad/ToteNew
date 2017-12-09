

using System;
using System.Collections.Generic;
using Common.Models;
using Data.TeamService;
using Data.Business;
using System.ServiceModel;

namespace Data.Clients
{
    public class MatchClient : IMatchClient
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MatchClient));
        private readonly IMatchConvert convert;

        public MatchClient(IMatchConvert convert)
        {
            this.convert = convert;
        }

        public bool AddMatch(Match match)
        {
            var matchDto = new MatchDto();
            matchDto = convert.ToMatchDto(match);
            var model = new bool();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.AddMatch(matchDto);
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

        public bool DeleteMatch(int matchId)
        {
            var model = new bool();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.DeleteMatch(matchId);
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

        public MatchDto GetMatchById(int matchId)
        {
            var model = new MatchDto();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.GetMatchById(matchId);
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

        public IReadOnlyList<SortDto> GetMatchBySportDateStatus(int sportId, string dateMatch, int status)
        {
            var model = new List<SortDto>();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    var matches = client.GetMatchBySportDateStatus(sportId, dateMatch, status);
                    foreach (var match in matches)
                    {
                        model.Add(match);
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

        public IReadOnlyList<MatchDto> GetMatchesAll()
        {
            var model = new List<MatchDto>();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    var matches = client.GetMatchesAll();
                    foreach (var match in matches)
                    {
                        model.Add(match);
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

        public IReadOnlyList<ResultDto> GetResultsAll()
        {
            var model = new List<ResultDto>();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    var results = client.GetResultsAll();
                    foreach (var result in results)
                    {
                        model.Add(result);
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

        public bool UpdateMatch(Match match)
        {
            var matchDto = new MatchDto();
            matchDto = convert.ToMatchDto(match);
            var model = new bool();
            using (var client = new TeamService.MatchServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.UpdateMatch(matchDto);
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
