using System;
using Common.Models;
using Data.Clients;
using Common.Logger;

namespace Business.Service
{
    public class UpdateSportService : IUpdateSportService
    {
        private readonly ISportClient sportClient;
        private readonly ILogService<UpdateSportService> logService;
        public UpdateSportService(ISportClient sportClient, ILogService<UpdateSportService> logService)
        {
            if (sportClient == null)
            {
                throw new ArgumentNullException();
            }
            this.sportClient = sportClient;
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
                return false;
            }
            return sportClient.AddSport(sport);
        }

        public bool DeleteSport(int sportId)
        {
            if (sportId <= 0)
            {
                logService.LogError("Class: UpdateSportService Method: DeleteSport  Sport don't delete from DB");
                return false;
            }
            return sportClient.DeleteSport(sportId);
        }

        public bool UpdateSport(Sport sport)
        {
            if (sport == null)
            {
                logService.LogError("Class: UpdateSportService Method: UpdateSport  Sport don't update from DB");
                return false;
            }
            return sportClient.UpdateSport(sport);
        }
    }
}
