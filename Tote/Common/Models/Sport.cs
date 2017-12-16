using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Sport
    {
        
        public int SportId { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Sport")]
        public string Name { get; set; }

        public IList<Team> Teams { get; set; }

        public IList<Tournament> Tournaments { get; set; }

        public Sport()
        {
            Teams = new List<Team>();
            Tournaments = new List<Tournament>();
        }

    }
}
