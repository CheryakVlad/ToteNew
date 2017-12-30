using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class ResultDto
    {
        
        [DataMember]
        public int ResultId { get; set; }
        [DataMember]
        public string Name { get; set; }
        
    }
}
