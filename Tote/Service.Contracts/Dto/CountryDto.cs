using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class CountryDto
    {
        [DataMember]
        public int CountryId { get; set; }
        [DataMember]
        public string Name { get; set; }
        

        
    }
}
