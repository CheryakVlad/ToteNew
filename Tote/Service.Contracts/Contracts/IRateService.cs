using Service.Contracts.Dto;
using System.ServiceModel;
using System.Collections.Generic;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IRateService
    {
        [OperationContract]
        RateDto GetRate(int? id);
        [OperationContract]
        IEnumerable<RateDto> GetRates();

        //IList<RatesListDto> GetRate(int? sportId, int? tournamentId);
    }
}
