using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class RoleDto
    {
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string Name { get; set; }
        
    }
}
