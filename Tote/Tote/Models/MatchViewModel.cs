using System;
using System.ComponentModel.DataAnnotations;

namespace Tote.Models
{
    public class MatchViewModel
    {
        [Required]
        public int SportId { get; set; }
        [Required]
        public int TournamentId { get; set; }
        [Required]
        public int TeamHomeId { get; set; }
        [Required]
        public int TeamGuestId { get; set; }
        [Required]
        public DateTime DateMatch { get; set; }        
        public int ResultId { get; set; }
        public string Score { get; set; }

    }
}