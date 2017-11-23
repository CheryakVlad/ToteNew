using Service.Contracts.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface ITournamentService
    {
        [OperationContract]
        TournamentDto GetTournament(int? id);
        [OperationContract]
        IEnumerable<TournamentDto> GetTournamentes();
    }
}
