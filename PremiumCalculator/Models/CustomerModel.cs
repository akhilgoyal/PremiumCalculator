using System;
using System.ComponentModel.DataAnnotations;

namespace PremiumCalculator.Models
{
    public class CustomerModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public decimal Premium { get; set; }
    }
}
