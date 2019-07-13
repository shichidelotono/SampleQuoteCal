using System;

namespace SampleQuoteApi.Repository
{
    public class QuoteEntity
    {
        public decimal AmountRequired { get; set; }
        public int Term { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime DateTimeAdded { get; set; }
    }
}
