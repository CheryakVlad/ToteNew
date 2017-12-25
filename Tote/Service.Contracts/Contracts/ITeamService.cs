using Service.Contracts.Dto;
using Service.Contracts.Exception;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface ITeamService
    {
        /*[OperationContract]
        [FaultContract(typeof(CustomException))]
        TeamDto[] GetTeam(int? teamId);*/
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        TeamDto[] GetTeams();
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        TeamDto GetTeamById(int teamId);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool UpdateTeam(TeamDto teamDto);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool AddTeam(TeamDto teamDto);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool DeleteTeam(int teamId);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        TeamDto[] GetTeamsByTournament(int tournamentId);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        CountryDto[] GetCountriesAll();
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        CountryDto GetCountryById(int countryId);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        CountryDto GetCountryByTeam(int teamId);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool UpdateCountry(CountryDto countryDto);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool AddCountry(CountryDto countryDto);
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool DeleteCountry(int countryId);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool AddTournamentForTeam(int tournamentId, int teamId);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool DeleteTournamentForTeam(int tournamentId, int teamId);

        


    }
}
