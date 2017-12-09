using Service.Contracts.Dto;
using System.ServiceModel;
using Service.Contracts.Exception;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IMatchService
    {        
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        MatchDto[] GetMatchesAll();
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        MatchDto GetMatchById(int matchId);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool UpdateMatch(MatchDto matchDto);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool AddMatch(MatchDto matchDto);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool DeleteMatch(int matchId);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        SortDto[] GetMatchBySportDateStatus(int sportId, string dateMatch, int status);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        ResultDto[] GetResultsAll();
    }
}
