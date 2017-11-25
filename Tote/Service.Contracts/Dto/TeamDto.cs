using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class TeamDto
    {
        [DataMember]
        public int TeamId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int SportId { get; set; }
        [DataMember]
        public int CountryId { get; set; }
        

    }
}
