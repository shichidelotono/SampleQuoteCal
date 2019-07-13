using System;
using System.ComponentModel.DataAnnotations;

namespace SampleQuoteApi.Repository
{
    public class QuoteDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal AmountRequired { get; set; }
        [Required]
        public int Term { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(128)]
        public string Mobile { get; set; }
        [Required]
        [MaxLength(128)]
        public string Email { get; set; }
        [Required]
        public DateTime DateTimeAdded { get; set; }
    }
}
