
namespace Common.Models
{
    public class Basket
    {
        public int BasketId { get; set; }
        public int UserId { get; set; }
        public string Login { get; set; }
        public int MatchId { get; set; }
        public int EventId { get; set; }
        public static double SumCoefficient{ get; set; }
        public Match Match { get; set; }
        public Tournament Tournament { get; set; }
    }
}
