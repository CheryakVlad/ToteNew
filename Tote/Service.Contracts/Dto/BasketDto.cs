using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class BasketDto
    {
        [DataMember]
        public int BasketId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public int MatchId { get; set; }
        [DataMember]
        public int EventId { get; set; }
        
    }
}
