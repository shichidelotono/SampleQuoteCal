using SampleQuoteApi.Domain;
using SampleQuoteApi.Repository;

namespace SampleQuoteApi.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuoteService(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public void AddQuote(Quote quoteDomain)
        {
            _quoteRepository.SaveQuote(quoteDomain.ToDbEntity());
        }
    }
}
