using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class CommandDto
    {
        [DataMember]
        public int CommandId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int SportId { get; set; }
    }
}
