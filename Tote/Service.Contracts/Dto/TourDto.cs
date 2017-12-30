using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class TourDto
    {
        [DataMember]
        public int TourId { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
