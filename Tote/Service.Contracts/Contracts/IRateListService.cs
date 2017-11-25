using Service.Contracts.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IRateListService
    {
        [OperationContract]
        List<BetListDto> GetBets(int? sportId, int? tournamentId);
        [OperationContract]
        List<BetListDto> GetBetsAll();

        [OperationContract]
        SportDto GetSport(int? id);
        [OperationContract]
        List<SportDto> GetSports();

        [OperationContract]
        List<TournamentDto> GetTournament(int? sportId);
        [OperationContract]
        List<TournamentDto> GetTournamentes();
    }
}
