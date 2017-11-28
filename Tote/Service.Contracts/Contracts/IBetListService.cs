using Service.Contracts.Dto;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IBetListService
    {
        [OperationContract]
        [FaultContract(typeof(SqlException))]
        List<BetListDto> GetBets(int? sportId, int? tournamentId);
        [OperationContract]
        [FaultContract(typeof(SqlException))]
        List<BetListDto> GetBetsAll();

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        SportDto GetSport(int? id);
        [OperationContract]
        [FaultContract(typeof(SqlException))]
        List<SportDto> GetSports();

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        List<TournamentDto> GetTournament(int? sportId);
        [OperationContract]
        [FaultContract(typeof(SqlException))]
        List<TournamentDto> GetTournamentes();
    }
}
