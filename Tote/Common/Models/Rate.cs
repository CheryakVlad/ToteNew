using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class Rate
    {
       
        public int RateId { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Amount of Rate")]
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Date Rate")]
        public DateTime DateRate { get; set; }
        public bool Status { get; set; }
    }
}
