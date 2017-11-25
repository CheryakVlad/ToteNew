using Service.Contracts.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface ITeamService
    {
        [OperationContract]
        TeamDto GetCommand(int? id);
        [OperationContract]
        IEnumerable<TeamDto> GetCommands();
    }
}
