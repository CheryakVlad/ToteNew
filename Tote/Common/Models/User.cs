using System.Collections.Generic;

namespace Common.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FIO { get; set; }
        public decimal Money { get; set; }
        public IList<Role> Roles { get; set; }
        public int RoleId { get; set; } 
        public string PhoneNumber { get; set; }

    }
}
