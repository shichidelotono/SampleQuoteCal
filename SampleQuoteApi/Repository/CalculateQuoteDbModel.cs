using System;
using System.ComponentModel.DataAnnotations;

namespace SampleQuoteApi.Repository
{
    public class CalculateQuoteDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string Mobile { get; set; }
        [Required]
        [MaxLength(128)]
        public string Email { get; set; }
        [Required]
        public decimal FinancialAmount { get; set; }
        [Required]
        public decimal Repayments { get; set; }
        [Required]
        public DateTime DateTimeAdded { get; set; }
    }
}
