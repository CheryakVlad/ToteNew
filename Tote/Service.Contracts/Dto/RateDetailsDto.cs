using System;
using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class RateDetailsDto
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
        [DataMember]        
        public string CommandHome { get; set; }
        [DataMember]
        public string CommandGuest { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
    }
}
