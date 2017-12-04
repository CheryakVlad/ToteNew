using System.Collections.Generic;

namespace Common.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public IList<User> Users { get; set; }
    }
}
