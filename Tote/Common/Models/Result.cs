using System.Collections.Generic;

namespace Common.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public string Name { get; set; }
        public IList<Match> Matches { get; set; }

        /*public Result()
        {
            Matches = new List<Match>();
        }*/
    }
}
