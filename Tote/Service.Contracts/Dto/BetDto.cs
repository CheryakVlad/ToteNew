using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class BetDto
    {
        [DataMember]
        public int BetId { get; set; }
        [DataMember]
        public int MatchId { get; set; }
        [DataMember]
        public bool? Status { get; set; }
        [DataMember]
        public string Stat { get; set; }
        [DataMember]
        public int EventId { get; set; }
        [DataMember]
        public int RateId { get; set; }
        [DataMember]
        public string Sport { get; set; }
        [DataMember]
        public string Tournament { get; set; }
    }
        
}
