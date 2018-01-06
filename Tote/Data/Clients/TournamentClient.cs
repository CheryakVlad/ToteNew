using System;
using Common.Models;
using Data.Business;
using System.ServiceModel;
using Data.ToteService;
using Common.Logger;
using System.Collections.Generic;

namespace Data.Clients
{
    public class TournamentClient : ITournamentClient
    {        
        private readonly ITournamentConvert tournamentConvert;
        private readonly ILogService<TournamentClient> logService;

        public TournamentClient(ITournamentConvert tournamentConvert) :this(tournamentConvert, new LogService<TournamentClient>())
        {

        }

        public TournamentClient(ITournamentConvert tournamentConvert, ILogService<TournamentClient> logService)
        {
            if (tournamentConvert == null)
            {
                throw new ArgumentNullException();
            }
            this.tournamentConvert = tournamentConvert;
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
            tournamentDto = tournamentConvert.ToTournamentDto(tournament);
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
            tournamentDto = tournamentConvert.ToTournamentDto(tournament);
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

        public IReadOnlyList<TournamentDto> GetTournament(int? sportId)
        {
            if (sportId <= 0)
            {
                logService.LogError("Class: BetListClient Method: DeleteBasket sportId is not positive");
                return null;
            }
            var model = new List<TournamentDto>();
            using (var client = new ToteService.TournamentServiceClient())
            {
                try
                {
                    client.Open();

                    var tournaments = client.GetTournament(sportId);
                    foreach (var tournament in tournaments)
                    {
                        model.Add(tournament);
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

        public IReadOnlyList<TournamentDto> GetTournamentes()
        {
            var model = new List<TournamentDto>();
            using (var client = new ToteService.TournamentServiceClient())
            {
                try
                {
                    client.Open();

                    var tournaments = client.GetTournamentes();
                    foreach (var tournament in tournaments)
                    {
                        model.Add(tournament);
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

        public IReadOnlyList<TournamentDto> GetTournamentesByTeamId(int teamId)
        {
            if (teamId <= 0)
            {
                logService.LogError("Class: BetListClient Method: DeleteBasket teamId is not positive");
                return null;
            }
            var model = new List<TournamentDto>();
            using (var client = new ToteService.TournamentServiceClient())
            {
                try
                {
                    client.Open();

                    var tournaments = client.GetTournamentesByTeamId(teamId);
                    foreach (var tournament in tournaments)
                    {
                        model.Add(tournament);
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

    }
}
