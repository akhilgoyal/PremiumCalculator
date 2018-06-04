using System;
using System.ComponentModel.DataAnnotations;

namespace PremiumCalculator.Models
{
    public class CustomerModel
    {
        [Required]
        public string Name { get; set; }


        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        public decimal Premium { get; set; }

        public string Result { get; set; }
    }
}
