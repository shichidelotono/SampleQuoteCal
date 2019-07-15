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

        public async Task AddQuote(Quote quoteDomain)
        {
            await _quoteRepository.SaveQuote(quoteDomain.ToDbEntity());
        }
    }
}
