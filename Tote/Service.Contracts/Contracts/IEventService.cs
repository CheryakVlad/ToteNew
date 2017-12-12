using Service.Contracts.Dto;
using Service.Contracts.Exception;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IEventService
    {
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        EventDto[] GetEvents(int id);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        EventDto[] GetEventsAll();

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool UpdateEvents(IReadOnlyList<EventDto> eventDto);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool AddEvents(IReadOnlyList<EventDto> eventDto);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool DeleteEvents(int matchId);
    }
}
