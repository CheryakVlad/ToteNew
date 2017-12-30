using System;
using Common.Models;
using Data.Clients;
using Common.Logger;

namespace Business.Service
{
    public class UpdateSportService : IUpdateSportService
    {
        private readonly IBetListClient betListClient;
        private readonly ILogService<UpdateSportService> logService;
        public UpdateSportService(IBetListClient betListClient, ILogService<UpdateSportService> logService)
        {
            if (betListClient == null)
            {
                throw new ArgumentNullException();
            }
            this.betListClient = betListClient;
            if (logService == null)
            {
                this.logService = new LogService<UpdateSportService>();
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
                logService.LogError("Class: UpdateSportService Method: AddSport  Sport don't add to DB");
                throw new NullReferenceException("Sport is null");
            }
            return betListClient.AddSport(sport);
        }

        public bool DeleteSport(int sportId)
        {
            if (sportId <= 0)
            {
                logService.LogError("Class: UpdateSportService Method: DeleteSport  Sport don't delete from DB");
                throw new ArgumentOutOfRangeException("sportId <= 0");
            }
            return betListClient.DeleteSport(sportId);
        }

        public bool UpdateSport(Sport sport)
        {
            if (sport == null)
            {
                logService.LogError("Class: UpdateSportService Method: UpdateSport  Sport don't update from DB");
                throw new NullReferenceException("Sport is null");
            }
            return betListClient.UpdateSport(sport);
        }
    }
}
