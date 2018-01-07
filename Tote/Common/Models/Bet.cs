﻿using System.Collections.Generic;

namespace Common.Models
{
    public class Bet
    {
        public int BetId { get; set; }
        public double WinCommandHome { get; set; }
        public double WinCommandGuest { get; set; }
        public double Draw { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }        
        public Event Event { get; set; }
        public int RateId { get; set; }
        public bool? Status { get; set; }
        public Sport Sport { get; set; }
        public Tournament Tournament { get; set; }


    }
}
