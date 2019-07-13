using SampleQuoteApi.Domain;
using SampleQuoteApi.Repository;

namespace SampleQuoteApi.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository quoteRepository;

        public QuoteService(IQuoteRepository quoteRepository)
        {
            this.quoteRepository = quoteRepository;
        }

        public void AddQuote(Quote quote)
        {
            // some business logic
            //quoteRepository.SaveQuote(quote.ToEntity());
        }

        // implement unit tests and integration test
    }
}
