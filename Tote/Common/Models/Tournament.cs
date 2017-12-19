using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Tournament")]
        public string Name { get; set; }
        public int SportId { get; set; }        
        public Sport Sport { get; set; }
        public IList<Match> Matches { get; set; }

        /*public Tournament()
        {
            Matches = new List<Match>();
        }*/
    }
}
