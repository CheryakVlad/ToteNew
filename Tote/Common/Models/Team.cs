namespace Common.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
