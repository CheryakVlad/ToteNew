using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        
        public DateTime Date { get; set; }
        public int SportId { get; set; }
        public string SportName { get; set; }
        public int TournamentId { get; set; }   
        public Tournament Tournament { get; set; }        
        public Result Result { get; set; }
        public string Score { get; set; }        
        public IList<Event> Events { get; set; }  
        public IList<Team> Teams { get; set; }

    }
}
