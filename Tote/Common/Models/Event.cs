using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Event
    {
        public int EventId { get; set; }
        /*[Required(ErrorMessage = "Required field")]
        [Display(Name = "Event")]*/
        public string Name { get; set; }
        /*[Required(ErrorMessage = "Required field")]
        [Display(Name = "Coefficient")]*/
        public double Coefficient { get; set; }
        public int MatchId { get; set; }
    }
}
