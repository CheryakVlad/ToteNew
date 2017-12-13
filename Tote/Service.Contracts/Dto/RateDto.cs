using System;
using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class RateDto
    {
        [DataMember]
        public int RateId { get; set; }
        [DataMember]
        public DateTime DateRate { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public int UserId { get; set; }
    }
}
