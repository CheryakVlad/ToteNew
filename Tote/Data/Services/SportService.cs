using Common.Logger;
using Common.Models;
using Data.Business;
using Data.Clients;
using System;
using System.Collections.Generic;

namespace Data.Services
{
    public class SportService:ISportService
    {
        private readonly ISportClient sportClient;        
        private readonly ISportConvert sportConvert;        
        private readonly ILogService<SportService> logService;

        public SportService(ISportClient sportClient, ISportConvert sportConvert, ILogService<SportService> logService)
        {
            if (sportClient == null || sportConvert == null )
            {
                throw new ArgumentNullException();
            }
            this.sportClient = sportClient;
            this.sportConvert = sportConvert;            
            if (logService == null)
            {
                this.logService = new LogService<SportService>();
            }
            else
            {
                this.logService = logService;
            }
        }


        public Sport GetSport(int? id)
        {
            var dto = sportClient.GetSport(id);

            if (dto != null)
            {
                return sportConvert.ToSport(dto);
            }
            logService.LogError("Class: DataService Method: GetSport Sport is null");
            return new Sport();
        }

        public IReadOnlyList<Sport> GetSports()
        {
            var dto = sportClient.GetSports();

            if (dto != null)
            {
                return sportConvert.ToSport(dto);
            }
            logService.LogError("Class: DataService Method: GetSports List<Sport> is null");
            return new List<Sport>();
        }
    }
}
