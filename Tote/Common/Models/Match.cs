using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Date Match")]
        public DateTime Date { get; set; }
        public int SportId { get; set; }
        public int TournamentId { get; set; }
        public int TeamHomeId { get; set; }
        public int TeamGuestId { get; set; }
       
        public Tournament Tournament { get; set; }
        public int ResultId { get; set; }
        public Result Result { get; set; }
        public string Score { get; set; }        
        public IList<Event> Events { get; set; }

        public IList<Bet> Bets { get; set; }

        public IList<Team> Teams { get; set; }
        public static double SumCoefficient { get; set; }

        /*public Match()
        {
            Bets = new List<Bet>();
        }*/

    }
}
