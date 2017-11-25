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
        public int WinCommandHome { get; set; }
        [DataMember]
        public int WinCommandGuest { get; set; }
        [DataMember]
        public int Draw { get; set; }
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
