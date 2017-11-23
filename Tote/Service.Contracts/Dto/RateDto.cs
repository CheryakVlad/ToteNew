using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class RateDto
    {
        [DataMember]
        public int RateId { get; set; }
        [DataMember]
        public double WinCommandHome { get; set; }
        [DataMember]
        public double WinCommandGuest { get; set; }
        [DataMember]
        public double Draw { get; set; }
        [DataMember]
        public int MatchId { get; set; }
    }
}
