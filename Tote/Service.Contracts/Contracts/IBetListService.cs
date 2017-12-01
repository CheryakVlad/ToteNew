using Service.Contracts.Dto;
using Service.Contracts.Exception;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IBetListService
    {
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        BetListDto[] GetBets(int? sportId, int? tournamentId);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        BetListDto[] GetBetsAll();

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        SportDto GetSport(int? id);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        SportDto[] GetSports();

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        TournamentDto[] GetTournament(int? sportId);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        TournamentDto[] GetTournamentes();
    }
}
