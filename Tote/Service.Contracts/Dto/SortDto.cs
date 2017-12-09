using System;
using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class SortDto
    {
        [DataMember]
        public int MatchId { get; set; }
        [DataMember]
        public string TeamHome { get; set; }
        [DataMember]
        public string TeamHomeCountry { get; set; }
        [DataMember]
        public string TeamGuest { get; set; }
        [DataMember]
        public string TeamGuestCountry { get; set; }
        [DataMember]
        public DateTime DateMatch { get; set;}
        [DataMember]
        public string Score { get; set; }
        [DataMember]
        public string Tournament { get; set; }
    }
}
