using Service.Contracts.Dto;
using System.ServiceModel;
using System.Collections.Generic;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IMatchService
    {
        [OperationContract]
        MatchDto GetMatch(int? id);
        [OperationContract]
        IEnumerable<MatchDto> GetMatches();
    }
}
