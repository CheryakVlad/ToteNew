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
        public int TeamIdHome { get; set; }
        [DataMember]
        public int TeamIdGuest { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int ResultId { get; set; }
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public int TournamentId { get; set; }
        [DataMember]
        public string Tournament { get; set; }
        [DataMember]
        public string TeamHome { get; set; }
        [DataMember]
        public string TeamGuest { get; set; }        
        [DataMember]
        public string CountryHome { get; set; }
        [DataMember]
        public int CountryGuestId { get; set; }
        [DataMember]
        public int CountryHomeId { get; set; }
        [DataMember]
        public string CountryGuest { get; set; }
        [DataMember]
        public string Score { get; set; }

    }
}
