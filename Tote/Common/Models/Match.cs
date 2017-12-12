using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        /*public int TeamIdHome { get; set; }
        public int TeamIdGuest { get; set; }*/
        public DateTime Date { get; set; }
        public int SportId { get; set; }
        public int TournamentId { get; set; }
        public int TeamHomeId { get; set; }
        public int TeamGuestId { get; set; }
        public Tournament Tournament { get; set; }
        public int ResultId { get; set; }
        public Result Result { get; set; }
        public string Score { get; set; }
        public int TourId { get; set; }
        public IList<Event> Events { get; set; }

        public IList<Bet> Bets { get; set; }

        public IList<Team> Teams { get; set; }

        /*public Match()
        {
            Bets = new List<Bet>();
        }*/
        
    }
}
