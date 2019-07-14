using System.ComponentModel.DataAnnotations;

namespace SampleQuoteApi.RequestModels
{
    public class CreateQuoteRequestModel
    {
        [Required]
        [Range(2100, 15001)]
        public decimal AmountRequired { get; set; }
        [Required]
        [Range(3, 36)]
        public int Term { get; set; }
        [Required]
        [StringLength(2)]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
