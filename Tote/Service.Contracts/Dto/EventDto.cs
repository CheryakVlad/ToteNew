using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class EventDto
    {
        [DataMember]
        public int EventId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Coefficient { get; set; }
        [DataMember]
        public int MatchId { get; set; }
    }
}
