using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class RateList
    {
       
        public int RateId { get; set; }        
        public double WinCommandHome { get; set; }        
        public double WinCommandGuest { get; set; }
        public double Draw { get; set; }
        public int MatchId { get; set; }
        public string CommandHome { get; set; }
        public string CommandGuest { get; set; }
        public DateTime Date { get; set; }
    }
}
