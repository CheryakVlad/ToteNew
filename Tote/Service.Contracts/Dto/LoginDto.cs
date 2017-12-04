using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class LoginDto
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public double Money { get; set; }
        [DataMember]
        public string FIO { get; set; }
        [DataMember]
        public string Role { get; set; }
    }
}
