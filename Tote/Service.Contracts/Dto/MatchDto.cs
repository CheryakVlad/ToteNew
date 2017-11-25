using System;
using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class MatchDto
    {
        [DataMember]
        public int MatchId { get; set; }
        [DataMember]
        public int CommandIdHome { get; set; }
        [DataMember]
        public int CommandIdGuest { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int ResultId { get; set; }
        [DataMember]
        public int TournamentId { get; set; }
        [DataMember]
        public int TourId { get; set; }

       
    }
}
