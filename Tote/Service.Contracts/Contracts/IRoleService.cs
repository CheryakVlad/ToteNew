using Service.Contracts.Dto;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IRoleService
    {
        [OperationContract]
        RoleDto GetRole(int? roleId);
        [OperationContract]
        RoleDto[] GetRoles();
    }
}
