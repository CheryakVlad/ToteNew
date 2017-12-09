

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class TournamentDto
    {
        [DataMember]
        public int TournamentId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int SportId { get; set; }
        [DataMember]
        public string Sport { get; set; }

    }
}
