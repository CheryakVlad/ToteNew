using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class SportDto
    {
        [DataMember]
        public int SportId { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
