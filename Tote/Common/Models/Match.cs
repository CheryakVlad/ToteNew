using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public int CommandIdHome { get; set; }
        public int CommandIdGuest { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public int TournamentId { get; set; }
        public int TourId { get; set; }
    }
}
