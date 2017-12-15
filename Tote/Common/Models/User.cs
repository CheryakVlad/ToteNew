using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "First and Last Name")]
        public string FIO { get; set; }
        [Required]
        [Display(Name = "Money")]
        public decimal Money { get; set; }
        public IList<Role> Roles { get; set; }
        public int RoleId { get; set; }
        [Required]
        [Display(Name = "Phone Numbers")]
        public string PhoneNumber { get; set; }

    }
}
