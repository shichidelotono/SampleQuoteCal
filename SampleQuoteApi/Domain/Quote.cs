using System;

namespace SampleQuoteApi.Domain
{
    public class Quote
    {
        public string Url { get; }
        public decimal AmountRequired { get; }
        public int Term { get; }
        public string Title { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Mobile { get; }
        public string Email { get; }

        public Quote()
        {
        }

        public object ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
