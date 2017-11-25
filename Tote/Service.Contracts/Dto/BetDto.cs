using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class BetDto
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
    }
        
}
