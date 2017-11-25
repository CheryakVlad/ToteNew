﻿using System.Collections.Generic;

namespace Common.Models
{
    public class Sport
    {
        
        public int SportId { get; set; }
        
        public string Name { get; set; }

        public IList<Team> Teams { get; set; }

        public IList<Tournament> Tournaments { get; set; }

        public Sport()
        {
            Teams = new List<Team>();
            Tournaments = new List<Tournament>();
        }

    }
}
