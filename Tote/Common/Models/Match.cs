using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        /*public int CommandIdHome { get; set; }
        public int CommandIdGuest { get; set; }*/
        public DateTime Date { get; set; }        
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public int ResultId { get; set; }
        public Result Result { get; set; }
        public int TourId { get; set; }

        public IList<Bet> Bets { get; set; }

        public IList<Team> Teams { get; set; }

        public Match()
        {
            Bets = new List<Bet>();
        }
        
    }
}
