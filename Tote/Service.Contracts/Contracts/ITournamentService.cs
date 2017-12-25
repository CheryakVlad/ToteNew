using Service.Contracts.Dto;
using Service.Contracts.Exception;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface ITournamentService
    {
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        TournamentDto[] GetTournament(int? sportId);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        TournamentDto[] GetTournamentes();
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        TournamentDto GetTournamentById(int tournamentId);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool UpdateTournament(TournamentDto tournamentDto);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool AddTournament(TournamentDto tournamentDto);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool DeleteTournament(int tournamentId);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        TournamentDto[] GetTournamentesByTeamId(int teamId);
        

    }
}
