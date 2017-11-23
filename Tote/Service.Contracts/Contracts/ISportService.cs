using Service.Contracts.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface ISportService
    {
        [OperationContract]
        SportDto GetSport(int? id);
        [OperationContract]
        IEnumerable<SportDto> GetSports();
    }
}
