using SampleQuoteApi.Domain;

namespace SampleQuoteApi.Services
{
    public interface IQuoteService
    {
        void AddQuote(Quote quoteDomain);
    }
}
