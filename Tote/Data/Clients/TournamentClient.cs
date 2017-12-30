using System;
using Common.Models;
using Data.Business;
using System.ServiceModel;
using Data.ToteService;
using log4net;
using Common.Logger;

namespace Data.Clients
{
    public class TournamentClient : ITournamentClient
    {        
        private readonly IConvert convert;
        private readonly ILogService<TournamentClient> logService;

        public TournamentClient(IConvert convert):this(convert, new LogService<TournamentClient>())
        {

        }

        public TournamentClient(IConvert convert, ILogService<TournamentClient> logService)
        {
            if (convert == null)
            {
                throw new ArgumentNullException();
            }
            this.convert = convert;
            if (logService == null)
            {
                this.logService = new LogService<TournamentClient>();
            }
            else
            {
                this.logService = logService;
            }
        }        

        public bool AddTournament(Tournament tournament)
        {
            if (tournament == null)
            {
                logService.LogError("Class: TournamentClient Method: AddTournament tournament is null");
                return false;
            }
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

        public bool DeleteTournament(int tournamentId)
        {
            if (tournamentId <= 0)
            {
                logService.LogError("Class: TournamentClient Method: AddTournament tournamentId is not positive");
                return false;
            }
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

        public TournamentDto GetTournamentById(int tournamentId)
        {
            if (tournamentId <= 0)
            {
                logService.LogError("Class: TournamentClient Method: GetTournamentById tournamentId is not positive");
                return null;
            }
            var model = new TournamentDto();
            using (var client = new ToteService.TournamentServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.GetTournamentById(tournamentId);
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

        public bool UpdateTournament(Tournament tournament)
        {
            if (tournament == null)
            {
                logService.LogError("Class: TournamentClient Method: UpdateTournament tournament is null");
                return false;
            }
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
