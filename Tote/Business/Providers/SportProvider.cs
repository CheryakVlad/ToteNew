

using Common.Logger;
using Common.Models;
using Data.Services;
using System;
using System.Collections.Generic;

namespace Business.Providers
{
    public class SportProvider :ISportProvider
    {
        private readonly ISportService sportService;        
        private readonly ILogService<SportProvider> logService;
        public SportProvider(ISportService sportService, ILogService<SportProvider> logService)
        {
            if (sportService == null)
            {
                throw new ArgumentNullException();
            }
            this.sportService = sportService;
            
            if (logService == null)
            {
                this.logService = new LogService<SportProvider>();
            }
            else
            {
                this.logService = logService;
            }
        }

        public Sport GetSport(int? id)
        {
            return sportService.GetSport(id);
        }

        public IReadOnlyList<Sport> GetSports()
        {
            return sportService.GetSports();
        }
    }
}
