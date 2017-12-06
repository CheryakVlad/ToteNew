using System;
using Common.Models;
using Data.Business;
using System.ServiceModel;
using Data.ToteService;

namespace Data.Clients
{
    public class TournamentClient : ITournamentClient
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TournamentClient));
        private readonly IConvert convert;

        public TournamentClient(IConvert convert)
        {
            this.convert = convert;
        }
        public bool AddTournament(Tournament tournament)
        {
            var tournamentDto = new TournamentDto();
            tournamentDto = convert.ToTournamentDto(tournament);
            var model = new bool();
            using (var client = new ToteService.TournamentServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.AddTournament(tournamentDto);
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

        public bool DeleteTournament(int tournamentId)
        {
            var model = new bool();
            using (var client = new ToteService.TournamentServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.DeleteTournament(tournamentId);
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

        public TournamentDto GetTournamentById(int tournamentId)
        {
            var model = new TournamentDto();
            using (var client = new ToteService.TournamentServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.GetTournamentById(tournamentId);
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

        public bool UpdateTournament(Tournament tournament)
        {
            var tournamentDto = new TournamentDto();
            tournamentDto = convert.ToTournamentDto(tournament);
            var model = new bool();
            using (var client = new ToteService.TournamentServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.UpdateTournament(tournamentDto);
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
