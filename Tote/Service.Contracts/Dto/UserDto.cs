using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    public class UserDto
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
        public decimal Money { get; set; }
        [DataMember]
        public string FIO { get; set; }
        [DataMember]
        public string Role { get; set; }
    }
}
