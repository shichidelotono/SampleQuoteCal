using SampleQuoteApi.Representation;

namespace SampleQuoteApi.Services
{
    public interface IQuoteService
    {
        void AddQuote(Quote quote);
    }
}
