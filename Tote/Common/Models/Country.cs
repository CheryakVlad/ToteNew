using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Country")]
        public string Name { get; set; }
        

        

    }
}
