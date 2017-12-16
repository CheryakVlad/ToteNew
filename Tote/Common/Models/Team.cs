using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Team")]
        public string Name { get; set; }
        public int SportId { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Sport")]
        public Sport Sport { get; set; }
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Country")]
        public Country Country { get; set; }
    }
}
