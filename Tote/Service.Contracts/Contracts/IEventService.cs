using Service.Contracts.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IEventService
    {
        [OperationContract]
        EventDto[] GetEvents(int? id);
        [OperationContract]
        EventDto[] GetEventsAll();
    }
}
