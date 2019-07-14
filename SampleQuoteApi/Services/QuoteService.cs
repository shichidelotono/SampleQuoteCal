using SampleQuoteApi.Domain;
using SampleQuoteApi.Repository;
using System.Threading.Tasks;

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
            Task.Factory.StartNew(() => _quoteRepository.SaveQuote(quoteDomain.ToDbEntity()));
        }
    }
}
