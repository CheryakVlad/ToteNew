using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Rate
    {
       
        public int RateId { get; set; }        
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public DateTime DateRate { get; set; }
    }
}
