using System.Collections.Generic;

namespace Common.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public IList<Team> Teams { get; set; }

        /*public Country()
        {
            Teams = new List<Team>();
        }*/

    }
}
