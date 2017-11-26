using System;
using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class BetListDto
    {
        [DataMember]
        public int BetId { get; set; }
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
        [DataMember]
        public string CountryHome { get; set; }
        [DataMember]
        public string CountryGuest { get; set; }
    }
}
