using Service.Contracts.Dto;
using Service.Contracts.Exception;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        UserDto[] GetUsers();

        /*[OperationContract]
        [FaultContract(typeof(CustomException))]
        UserDto[] GetUsersByRole(int RoleId);*/

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        UserDto GetUser(int userId);       
        
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        UserDto ExistsUser(string login, string password);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        RoleDto[] GetRoles();

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool UpdateUser(UserDto userDto);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool AddUser(UserDto userDto);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool DeleteUser(int userId);

    }
}
