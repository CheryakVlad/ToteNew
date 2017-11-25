﻿using System.Collections.Generic;

namespace Common.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public IList<Match> Matches { get; set; }

        public Tournament()
        {
            Matches = new List<Match>();
        }
    }
}
