using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Contracts.Dto;
using Service.Contracts.Context;

namespace Service.Contracts.Contracts
{
    public class RateService : IRateService
    {
        private readonly ToteContext db;
        public RateDto GetRate(int? id)
        {
            var selectedRate = from Rate in db.Rates
                               where Rate.MatchId == id
                               select Rate;
            return selectedRate.First();
        }

        public IEnumerable<RateDto> GetRates()
        {
            return db.Rates;
        }
    }
}
