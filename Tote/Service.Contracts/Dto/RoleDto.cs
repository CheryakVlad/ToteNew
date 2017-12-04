using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class RoleDto
    {
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string Name { get; set; }
        
    }
}
