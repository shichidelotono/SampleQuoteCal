using System;
using SampleQuoteApi.RequestModels;

namespace SampleQuoteApi.Representation
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

        public Quote()//fill here
        {
        }

        internal object ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
