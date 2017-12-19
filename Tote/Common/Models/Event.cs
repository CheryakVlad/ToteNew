using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Event
    {
        public int EventId { get; set; }        
        public string Name { get; set; }       
        public double Coefficient { get; set; }
        public int MatchId { get; set; }
    }
}
