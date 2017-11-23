using Service.Contracts.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface ICommandService
    {
        [OperationContract]
        CommandDto GetCommand(int? id);
        [OperationContract]
        IEnumerable<CommandDto> GetCommands();
    }
}
