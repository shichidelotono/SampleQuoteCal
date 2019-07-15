namespace SampleQuoteApi.Models
{
    public class QuoteFormModel
    {
        public decimal AmountRequired { get; set; }
        public int Term { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int MinTerm { get; set; }
        public int MaxTerm { get; set; }
        public int MinAmountRequired { get; set; }
        public int MaxAmountRequired { get; set; }
    }
}
