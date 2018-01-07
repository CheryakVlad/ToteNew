using Common.Logger;
using Common.Models;
using Data.Business;
using Data.ToteService;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Data.Clients
{
    public class SportClient:ISportClient
    {
        private readonly ISportConvert sportConvert;
        private readonly ILogService<SportClient> logService;
        

        public SportClient(ISportConvert sportConvert, ILogService<SportClient> logService)
        {
            if (sportConvert == null)
            {
                throw new ArgumentNullException();
            }
            this.sportConvert = sportConvert;
            if (logService == null)
            {
                this.logService = new LogService<SportClient>();
            }
            else
            {
                this.logService = logService;
            }
        }


        public bool AddSport(Sport sport)
        {
            if (sport == null)
            {
                logService.LogError("Class: BetListClient Method: AddSport Sport is null");
                return false;
            }
            var sportDto = new SportDto();
            sportDto = sportConvert.ToSportDto(sport);
            var model = new bool();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.AddSport(sportDto);
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

        public bool DeleteSport(int sportId)
        {
            if (sportId <= 0)
            {
                logService.LogError("Class: BetListClient Method: DeleteBasket sportId is not positive");
                return false;
            }
            var model = new bool();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.DeleteSport(sportId);
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


        public SportDto GetSport(int? id)
        {
            if (id <= 0)
            {
                logService.LogError("Class: BetListClient Method: DeleteBasket id is not positive");
                return null;
            }
            var model = new SportDto();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.GetSport(id);
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

        public IReadOnlyList<SportDto> GetSports()
        {
            var model = new List<SportDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();

                    var sports = client.GetSports();
                    foreach (var sport in sports)
                    {
                        model.Add(sport);
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

        public bool UpdateSport(Sport sport)
        {
            if (sport == null)
            {
                logService.LogError("Class: BetListClient Method: DeleteBasket sport is null");
                return false;
            }
            var sportDto = new SportDto();
            sportDto = sportConvert.ToSportDto(sport);
            var model = new bool();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.UpdateSport(sportDto);
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
